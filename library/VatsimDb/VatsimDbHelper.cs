using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Serilog;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimData;

namespace VatsimLibrary.VatsimDb
{
    public class VatsimDbHelper
    {

        public static readonly string DATA_DIR;

        static VatsimDbHelper()
        {
            DirectoryInfo data_dir = new DirectoryInfo(Environment.CurrentDirectory);
            DATA_DIR = $@"{data_dir.Parent}\data\";
        }

        public static async Task<VatsimClientATCV1> FindControllerAsync(string cid, string callsign, string timelogon)
        {
            using(var db = new VatsimDbContext())
            {
                return await db.Controllers.FindAsync(cid, callsign, timelogon);
            }            
        }

        public static async void UpdateOrCreateATCAsync(VatsimClientATCV1 controller)
        {

            using(var db = new VatsimDbContext())
            {

                var _controller = await FindControllerAsync(controller.Cid, controller.Callsign, controller.TimeLogon);

                // didn't find the pilot
                if(_controller == null)
                {
                    await db.AddAsync(controller);
                    await db.SaveChangesAsync();
                    Log.Information($"Added Controller: {controller} to DB");                    
                }
                else
                {
                    // DateTime old_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(_controller.TimeLogon);
                    // DateTime new_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(controller.TimeLogon);

                    if(LogonTimeIsMoreRecent(_controller.TimeLogon, controller.TimeLogon))
                    {
                        await db.AddAsync(controller);
                        await db.SaveChangesAsync();
                        Log.Information($"Added Controller: {controller} to DB");                        
                    }
                    else
                    {
                        _controller.Update(controller);
                        db.Update(_controller);
                        await db.SaveChangesAsync();
                        Log.Information($"Updated Controller: {controller} in DB");
                    }
                }
            }
        }

        public static async void CreateControllersFromListAsync(IEnumerable<VatsimClientATCV1> controllers)
        {
            using(var db = new VatsimDbContext())
            {
                await db.Controllers.AddRangeAsync(controllers);
                await db.SaveChangesAsync();                
            }   
        }        

        public static async void UpdateControllersFromListAsync(IEnumerable<VatsimClientATCV1> controllers)
        {
            using(var db = new VatsimDbContext())
            {
                db.Controllers.UpdateRange(controllers);
                await db.SaveChangesAsync();
            }
        }

        public static async Task<VatsimClientPilotV1> FindPilotAsync(string cid, string callsign, string timelogon)
        {
            using(var db = new VatsimDbContext())
            {
                return await db.Pilots.FindAsync(cid, callsign, timelogon);
            }            
        }


        public static async void UpdateOrCreatePilotAsync(VatsimClientPilotV1 pilot)
        {

            using(var db = new VatsimDbContext())
            {

                var _pilot = await FindPilotAsync(pilot.Cid, pilot.Callsign, pilot.TimeLogon);

                // didn't find the pilot
                if(_pilot == null)
                {
                    await db.AddAsync(pilot);
                    await db.SaveChangesAsync();
                    Log.Information($"Added Pilot: {pilot} to DB");
                }
                else
                {
                    // DateTime old_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(_pilot.TimeLogon);
                    // DateTime new_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(pilot.TimeLogon);
                    if(LogonTimeIsMoreRecent(_pilot.TimeLogon, pilot.TimeLogon))
                    {
                        await db.AddAsync(pilot);
                        await db.SaveChangesAsync();
                        Log.Information($"Added Pilot: {pilot} to DB");                             
                    }
                    else
                    {
                        _pilot.Update(pilot);
                        db.Update(_pilot);
                        await db.SaveChangesAsync();
                        Log.Information($"Updated Pilot: {pilot} in DB");
                    }
                }
            }
        }

        public static async void CreatePilotsFromListAsync(IEnumerable<VatsimClientPilotV1> pilots)
        {
            using(var db = new VatsimDbContext())
            {
                await db.Pilots.AddRangeAsync(pilots);
                await db.SaveChangesAsync();                
            }   
        }        

        public static async void UpdatePilotsFromListAsync(IEnumerable<VatsimClientPilotV1> pilots)
        {
            using(var db = new VatsimDbContext())
            {
                db.Pilots.UpdateRange(pilots);
                await db.SaveChangesAsync();
            }
        }

        public static async Task<VatsimClientPlannedFlightV1> FindFlightAsync(
            string cid,
            string callsign,
            string timelogon,
            string dep,
            string dest)
        {
            using(var db = new VatsimDbContext())
            {
                return await db.Flights.FindAsync(cid, 
                                                  callsign,
                                                  timelogon, 
                                                  dep, 
                                                  dest);
            }            
        }

        public static async void UpdateOrCreateFlightAsync(VatsimClientPlannedFlightV1 flight)
        {

            using(var db = new VatsimDbContext())
            {
                var _flight = await FindFlightAsync(flight.Cid, 
                                                    flight.Callsign,
                                                    flight.TimeLogon, 
                                                    flight.PlannedDepairport, 
                                                    flight.PlannedDestairport);

                // didn't find the pilot
                if(_flight == null)
                {
                    await db.AddAsync(flight);
                    await db.SaveChangesAsync();
                    Log.Information($"Added Flight: {flight} to DB");
                }
                else
                {
                    // log.Info($"Flight found in DB: {_flight.ToString()}");
                    // DateTime old_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(_flight.TimeLogon);
                    // DateTime new_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(flight.TimeLogon);
                    if(LogonTimeIsMoreRecent(_flight.TimeLogon, flight.TimeLogon))
                    {
                        await db.AddAsync(flight);
                        await db.SaveChangesAsync();
                        Log.Information($"Added Flight: {flight} to DB");
                    }
                    else
                    {
                        _flight.Update(flight);
                        db.Update(_flight);
                        await db.SaveChangesAsync();
                        Log.Information($"Updated Flight: {flight} in DB");
                    }
                }
            }
        }

        public static async void CreateFlightsFromListAsync(IEnumerable<VatsimClientPlannedFlightV1> flights)
        {
            using(var db = new VatsimDbContext())
            {
                await db.Flights.AddRangeAsync(flights);
                await db.SaveChangesAsync();                
            }   
        }

        public static async void UpdateFlightsFromListAsync(IEnumerable<VatsimClientPlannedFlightV1> flights)
        {
            using(var db = new VatsimDbContext())
            {
                db.Flights.UpdateRange(flights);
                await db.SaveChangesAsync();
            }
        }        

        /// <summary>
        /// Save a position to the database
        /// </summary>
        /// <param name="position">position snapshot information</param>
        public static async void CreatePositionAsync(VatsimClientPilotSnapshotV1 position)
        {

            using(var db = new VatsimDbContext())
            {
                // make sure we have a position to write
                if(position != null)
                {
                    await db.AddAsync(position);
                    await db.SaveChangesAsync();

                    Log.Information($"Added Position: {position} to DB");
                }
            }
        }

        public static async void CreatePositionsFromListAsync(IEnumerable<VatsimClientPilotSnapshotV1> positions)
        {
            using(var db = new VatsimDbContext())
            {
                await db.Positions.AddRangeAsync(positions);
                await db.SaveChangesAsync();                
            }   
        }        

        public static bool LogonTimeIsMoreRecent(string logontime_old, string logontime_new)
        {
            DateTime old_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(logontime_old);
            DateTime new_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(logontime_new);
            return new_time > old_time;
        }
    }
}