using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;
using VatsimLibrary.VatsimUtils;

namespace VatsimLibrary.VatsimData
{
    public class VatsimDataState
    {

        private const bool IFRONLY = true;

        // List of Vatsim Client Records
        public List<VatsimClientRecord> VatsimClientRecords {get; set; } = new List<VatsimClientRecord>();

        public string VatsimDataUrl {get; set;}
        public string VatsimServersUrl {get; set;}
        public string VatsimMetarUrl {get; set;}
        public string VatsimDataVersion {get; set;}
        public string VatsimDataReload {get; set;}
        public DateTime VatsimDataLastUpdated { get; set;}
        public string VatsimDataConnectedClients {get; set;}
        public string VatsimDataUniqueUsers {get; set;}

        public static DateTime GetDateTimeFromVatsimTimeStamp(string vatsimtimestamp)
        {

            int year = Convert.ToInt32(vatsimtimestamp.Substring(0,4));
            int month = Convert.ToInt32(vatsimtimestamp.Substring(4,2));
            int day = Convert.ToInt32(vatsimtimestamp.Substring(6,2));
            int hour = Convert.ToInt32(vatsimtimestamp.Substring(8,2));
            int minute = Convert.ToInt32(vatsimtimestamp.Substring(10,2));
            int second = Convert.ToInt32(vatsimtimestamp.Substring(12,2));
            
            return new DateTime(year, month, day, hour, minute, second);

        }

        public async void BatchProcessVatsimClientRecords()
        {
            // are there any clients to process?
            if(VatsimClientRecords != null && VatsimClientRecords.Count > 0)
            {
                Console.Write("Writing Vatsim Objects to Database... ");
                // progress bar
                using(var progress = new ConsoleProgressBar())
                {   
                    // get total count
                    int count = 0;
                    int total = VatsimClientRecords.Count;

                    //lists for controllers
                    List<VatsimClientATCV1> controllerAddList = new List<VatsimClientATCV1>();
                    List<VatsimClientATCV1> controllerUpdateList = new List<VatsimClientATCV1>();

                    List<VatsimClientPilotV1> pilotsAddList = new List<VatsimClientPilotV1>();
                    List<VatsimClientPilotV1> pilotsUpdateList = new List<VatsimClientPilotV1>();

                    List<VatsimClientPlannedFlightV1> flightsAddList = new List<VatsimClientPlannedFlightV1>();
                    List<VatsimClientPlannedFlightV1> flightsUpdateList = new List<VatsimClientPlannedFlightV1>();

                    List<VatsimClientPilotSnapshotV1> positionsList = new List<VatsimClientPilotSnapshotV1>();


                    try
                    {
                        foreach (VatsimClientRecord record in VatsimClientRecords)
                        {
                            progress.Report((double)count++ / total);
                            Thread.Sleep(20);

                            switch(record.Clienttype)
                            {
                                case "ATC":
                                    var _controller = await VatsimDbHelper.FindControllerAsync(record.Cid, record.Callsign, record.TimeLogon);
                                    var controller = record.GetVatsimClientATCFromRecord();
                                    if(_controller != null)
                                    {
                                        if(VatsimDbHelper.LogonTimeIsMoreRecent(_controller.TimeLogon, record.TimeLogon))
                                        {
                                            controllerAddList.Add(controller);                                            
                                        }
                                        else
                                        {
                                            _controller.Update(controller);
                                            controllerUpdateList.Add(_controller);
                                        }
                                    }
                                    else
                                    {
                                        controllerAddList.Add(controller);
                                    }
                                    break;

                                case "PILOT":
                                    // only process IFR flights
                                    if(IFRONLY)
                                    {
                                        // check to see that this pilot has an IFR Plan Active
                                        if(IFRFlightPlanActive(record))
                                        {
                                            //VatsimDbHepler.UpdateOrCreatePilotAsync(record.GetVatsimClientPilotFromRecord());
                                            //look for pilot
                                            var _pilot = await VatsimDbHelper.FindPilotAsync(record.Cid, record.Callsign, record.TimeLogon);
                                            var pilot = record.GetVatsimClientPilotFromRecord();
                                            if(_pilot != null)
                                            {
                                                if(VatsimDbHelper.LogonTimeIsMoreRecent(_pilot.TimeLogon, pilot.TimeLogon))
                                                {
                                                    pilotsAddList.Add(pilot);                                                    

                                                }
                                                else
                                                {
                                                    _pilot.Update(pilot);
                                                    pilotsUpdateList.Add(_pilot);
                                                }
                                            }
                                            else
                                            {
                                                pilotsAddList.Add(pilot);
                                            }

                                            //look for flight plan
                                            //VatsimDbHepler.UpdateOrCreateFlightAsync(record.GetVatsimClientPlannedFlightFromRecord());                                            
                                            var _flight = await VatsimDbHelper.FindFlightAsync(record.Cid, 
                                                                                               record.Callsign,
                                                                                               record.TimeLogon,
                                                                                               record.PlannedDepairport,
                                                                                               record.PlannedDestairport);
                                            var flight = record.GetVatsimClientPlannedFlightFromRecord();
                                            if(_flight != null)
                                            {
                                                if(VatsimDbHelper.LogonTimeIsMoreRecent(_flight.TimeLogon, flight.TimeLogon))
                                                {
                                                    flightsAddList.Add(flight);
                                                }
                                                else
                                                {
                                                    _flight.Update(flight);
                                                    flightsUpdateList.Add(_flight);                                                    
                                                }
                                                    
                                            }
                                            else
                                            {
                                                flightsAddList.Add(flight);
                                            }

                                            //create position update
                                            positionsList.Add(record.GetVatsimClientPilotSnapshotFromRecord());
                                        }
                                    }
                                    break;
                            }
                        }

                        // make db changes
                        // controllers
                        VatsimDbHelper.UpdateControllersFromListAsync(controllerUpdateList);
                        VatsimDbHelper.CreateControllersFromListAsync(controllerAddList);

                        //pilots
                        VatsimDbHelper.UpdatePilotsFromListAsync(pilotsUpdateList);
                        VatsimDbHelper.CreatePilotsFromListAsync(pilotsAddList);

                        //flights
                        VatsimDbHelper.UpdateFlightsFromListAsync(flightsUpdateList);
                        VatsimDbHelper.CreateFlightsFromListAsync(flightsAddList);

                        //positions
                        VatsimDbHelper.CreatePositionsFromListAsync(positionsList);


                    }
                    catch(Exception exp)
                    {
                        Console.WriteLine($"{exp.StackTrace}");
                    }
                }

                Console.WriteLine("Done.");                
            }
        }

        /// <summary>
        /// Run through the list of clients to parse out ATC and Pilots
        /// </summary>
        public void ProcessVatsimClientRecords()
        {
            // are there any clients to process?
            if(VatsimClientRecords != null && VatsimClientRecords.Count > 0)
            {
                Console.Write("Writing Vatsim Objects to Database... ");
                // progress bar
                using(var progress = new ConsoleProgressBar())
                {                
                    // get total count
                    int count = 0;
                    int total = VatsimClientRecords.Count;
                    try
                    {
                        foreach (VatsimClientRecord record in VatsimClientRecords)
                        {
                            progress.Report((double)count++ / total);
                            Thread.Sleep(20);

                            switch(record.Clienttype)
                            {
                                case "ATC":
                                    VatsimDbHelper.UpdateOrCreateATCAsync(record.GetVatsimClientATCFromRecord());
                                    break;

                                case "PILOT":
                                    // only process IFR flights
                                    if(IFRONLY)
                                    {
                                        // check to see that this pilot has an IFR Plan Active
                                        if(IFRFlightPlanActive(record))
                                        {
                                            VatsimDbHelper.UpdateOrCreatePilotAsync(record.GetVatsimClientPilotFromRecord());
                                            VatsimDbHelper.UpdateOrCreateFlightAsync(record.GetVatsimClientPlannedFlightFromRecord());
                                            VatsimDbHelper.CreatePositionAsync(record.GetVatsimClientPilotSnapshotFromRecord());
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    catch(Exception exp)
                    {
                        Console.WriteLine($"{exp.Message}");
                    }
                }

                Console.WriteLine("Done.");                
            }
        }

        public bool IFRFlightPlanActive(VatsimClientRecord record)
        {
            // only filed/active IFR flight types
            if( record.PlannedDepairport != "" && 
                record.PlannedDestairport != "" &&
                record.PlannedFlighttype != "" &&
                record.PlannedFlighttype == "I")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}            
