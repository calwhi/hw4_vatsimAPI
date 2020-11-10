using System;

using VatsimLibrary.VatsimClientV1;

namespace VatsimLibrary.VatsimData
{
    public class VatsimClientRecord
    {

        public static readonly char FIELD_DELIMITER = ':';

        // callsign:
        public static readonly int CALLSIGN_INDEX = 0;
        // cid:
        public static readonly int CID_INDEX = 1;
        // realname:
        public static readonly int REALNAME_INDEX = 2;
        // clienttype:
        public static readonly int CLIENTTYPE_INDEX = 3;
        // frequency:
        public static readonly int FREQUENCY_INDEX = 4;
        // latitude:
        public static readonly int LATITUDE_INDEX = 5;
        // longitude:
        public static readonly int LONGITUDE_INDEX = 6;
        // altitude:
        public static readonly int ALTITUDE_INDEX = 7;
        // groundspeed:
        public static readonly int GROUNDSPEED_INDEX = 8;
        // planned_aircraft:
        public static readonly int PLANNED_AIRCRAFT_INDEX = 9;
        // planned_tascruise:
        public static readonly int PLANNED_TASCRUISE_INDEX = 10;
        // planned_depairport:
        public static readonly int PLANNED_DEPAIRPORT_INDEX = 11;
        // planned_altitude:
        public static readonly int PLANNED_ALTITUDE_INDEX = 12;
        // planned_destairport:
        public static readonly int PLANNED_DESTAIRPORT_INDEX = 13;
        // server:
        public static readonly int SERVER_INDEX = 14;
        // protrevision:
        public static readonly int PROTREVISION_INDEX = 15;
        // rating:
        public static readonly int RATING_INDEX = 16;
        // transponder:
        public static readonly int TRANSPONDER_INDEX = 17;
        // facilitytype:
        public static readonly int FACILITYTYPE_INDEX = 18;
        // visualrange:
        public static readonly int VISUALRANGE_INDEX = 19;
        // planned_revision:
        public static readonly int PLANNED_REVISION_INDEX = 20;
        // planned_flighttype:
        public static readonly int PLANNED_FLIGHTTYPE_INDEX = 21;
        // planned_deptime:
        public static readonly int PLANNED_DEPTIME_INDEX = 22;
        // planned_actdeptime:
        public static readonly int PLANNED_ACTDEPTIME_INDEX = 23;
        // planned_hrsenroute:
        public static readonly int PLANNED_HRSENROUTE_INDEX = 24;
        // planned_minenroute:
        public static readonly int PLANNED_MINENROUTE_INDEX = 25;
        // planned_hrsfuel:
        public static readonly int PLANNED_HRSFUEL_INDEX = 26;
        // planned_minfuel:
        public static readonly int PLANNED_MINFUEL_INDEX = 27;
        // planned_altairport:
        public static readonly int PLANNED_ALTAIRPORT_INDEX = 28;
        // planned_remarks:
        public static readonly int PLANNED_REMARKS_INDEX = 29;
        // planned_route:
        public static readonly int PLANNED_ROUTE_INDEX = 30;
        // planned_depairport_lat:
        public static readonly int PLANNED_DEPAIRPORT_LAT_INDEX = 31;
        // planned_depairport_lon:
        public static readonly int PLANNED_DEPAIRPORT_LON_INDEX = 32;
        // planned_destairport_lat:
        public static readonly int PLANNED_DESTPAIRPORT_LAT_INDEX = 33;
        // planned_destairport_lon:
        public static readonly int PLANNED_DESTAIRPORT_LON_INDEX = 34;
        // atis_message:
        public static readonly int ATIS_MESSAGE_INDEX = 35;
        // time_last_atis_received:
        public static readonly int TIME_LAST_ATIS_RECEIVED_INDEX = 36;
        // time_logon:
        public static readonly int TIME_LOGON_INDEX = 37;
        // heading:
        public static readonly int HEADING_INDEX = 38;
        // QNH_iHg:
        public static readonly int QNH_IHG_INDEX = 39;
        // QNH_Mb:        
        public static readonly int QNH_MB_INDEX = 40;

        /* Sample fields and data */
        /*
        callsign:DLH1988:
        cid:1306122:
        realname:Thales Toledo SBST:
        clienttype:PILOT:
        frequency::
        latitude:-21.38394:
        longitude:-41.93211:
        altitude:37716:
        groundspeed:307:
        planned_aircraft:H/B78X/L:
        planned_tascruise:445:
        planned_depairport:EDDF:
        planned_altitude:38000:
        planned_destairport:SBGL:
        server:GERMANY-1:
        protrevision:100:
        rating:1:
        transponder:3436:
        facilitytype:0:
        visualrange:0:
        planned_revision:2:
        planned_flighttype:I:
        planned_deptime:201:
        planned_actdeptime:0:
        planned_hrsenroute:11:
        planned_minenroute:17:
        planned_hrsfuel:13:
        planned_minfuel:33:
        planned_altairport:SBGR:
        planned_remarks:PBN/A1B1C1D1L1O1S2 DOF/201007 REG/DAIHC EET/EDUU0013 LSAS0022 LFFF0035 LECM0121 GMMM0226 GCCC0322 GOOO0455 GVSC0500 GOOO0548 SBAO0713 SBRE0806 SBCW1035 OPR/DLH PER/D RMK/TCAS SIMBRIEF /v/:
        planned_route:ANEKI9F ANEKI Y163 HERBI Y164 MOPAN/N0471F310 Y164 OLBEN/N0492F350 UN869 ZAR UZ245 CJN/N0487F370 UN10 SVL UN857 DEREV/N0488F380 UN857 ERETU/N0484F400 UN857 MOLSU UTBOM2A:
        planned_depairport_lat:0:
        planned_depairport_lon:0:
        planned_destairport_lat:0:
        planned_destairport_lon:0:
        atis_message::
        time_last_atis_received:20201007021853:
        time_logon:20201007021853:
        heading:209:
        QNH_iHg:29.94:
        QNH_Mb:1014:
        */

        public string Callsign { get; set; }
        public string Cid { get; set; }
        public string Realname { get; set; }
        public string Clienttype { get; set; }
        public string Frequency { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Altitude { get; set; }
        public string Groundspeed { get; set; }
        public string PlannedAircraft { get; set; }
        public string PlannedTascruise { get; set; }
        public string PlannedDepairport { get; set; }
        public string PlannedAltitude { get; set; }
        public string PlannedDestairport { get; set; }
        public string Server { get; set; }
        public string Protrevision { get; set; }
        public string Rating { get; set; }
        public string Transponder { get; set; }
        public string Facilitytype { get; set; }
        public string Visualrange { get; set; }
        public string PlannedRevision { get; set; }
        public string PlannedFlighttype { get; set; }
        public string PlannedDeptime { get; set; }
        public string PlannedActdeptime { get; set; }
        public string PlannedHrsenroute { get; set; }
        public string PlannedMinenroute { get; set; }
        public string PlannedHrsfuel { get; set; }
        public string PlannedMinfuel { get; set; }
        public string PlannedAltairport { get; set; }
        public string PlannedRemarks { get; set; }
        public string PlannedRoute { get; set; }
        public string PlannedDepairportLat { get; set; }
        public string PlannedDepairportLon { get; set; }
        public string PlannedDestairportLat { get; set; }
        public string PlannedDestairportLon { get; set; }
        public string AtisMessage { get; set; }
        public string TimeLastAtisReceived { get; set; }
        public string TimeLogon { get; set; }
        public string Heading { get; set; }
        public string QNH_iHg { get; set; }
        public string QNH_Mb { get; set; }

        /// <summary>
        /// Read a line from the vatsim data file and parse out appropriate VatsimClientRecord object.
        /// https://status.vatsim.net/
        /// </summary>
        /// <param name="line">A line containing client data from vatsim-data.txt</param>
        /// <returns>VatsimClientRecord object</returns>
        public static VatsimClientRecord GetVatsimClientRecord(string line)
        {

            VatsimClientRecord record = new VatsimClientRecord();

            string[] parts = line.Split(FIELD_DELIMITER);

            // Console.WriteLine($"NUMBER OF PARTS: {parts.Length}");

            if(parts.Length == 42)
            {
                // callsign
                record.Callsign = parts[CALLSIGN_INDEX];
                // cid
                record.Cid = parts[CID_INDEX];
                // realname
                record.Realname = parts[REALNAME_INDEX];
                // clienttype
                record.Clienttype = parts[CLIENTTYPE_INDEX];
                // frequency
                record.Frequency = parts[FREQUENCY_INDEX];
                // latitude
                record.Latitude = parts[LATITUDE_INDEX];
                // longitude
                record.Longitude = parts[LONGITUDE_INDEX];
                // altitude
                record.Altitude = parts[ALTITUDE_INDEX];
                // groundspeed
                record.Groundspeed = parts[GROUNDSPEED_INDEX];
                // planned_aircraft
                record.PlannedAircraft = parts[PLANNED_AIRCRAFT_INDEX];
                // planned_tascruise
                record.PlannedTascruise = parts[PLANNED_TASCRUISE_INDEX];
                // planned_depairport
                record.PlannedDepairport = parts[PLANNED_DEPAIRPORT_INDEX];
                // planned_altitude
                record.PlannedAltitude = parts[PLANNED_ALTITUDE_INDEX];
                // planned_destairport
                record.PlannedDestairport = parts[PLANNED_DESTAIRPORT_INDEX];
                // server
                record.Server = parts[SERVER_INDEX];
                // protrevision
                record.Protrevision = parts[PROTREVISION_INDEX];
                // rating
                record.Rating = parts[RATING_INDEX];
                // transponder
                record.Transponder = parts[TRANSPONDER_INDEX];
                // facilitytype
                record.Facilitytype = parts[FACILITYTYPE_INDEX];
                // visualrange
                record.Visualrange = parts[VISUALRANGE_INDEX];
                // planned_revision
                record.PlannedRevision = parts[PLANNED_REVISION_INDEX];
                // planned_flighttype
                record.PlannedFlighttype = parts[PLANNED_FLIGHTTYPE_INDEX];
                // planned_deptime
                record.PlannedDeptime = parts[PLANNED_DEPTIME_INDEX];
                // planned_actdeptime
                record.PlannedActdeptime = parts[PLANNED_ACTDEPTIME_INDEX];
                // planned_hrsenroute
                record.PlannedHrsenroute = parts[PLANNED_HRSENROUTE_INDEX];
                // planned_minenroute
                record.PlannedMinenroute = parts[PLANNED_MINENROUTE_INDEX];
                // planned_hrsfuel
                record.PlannedHrsfuel = parts[PLANNED_HRSFUEL_INDEX];
                // planned_minfuel
                record.PlannedMinfuel = parts[PLANNED_MINFUEL_INDEX];
                // planned_altairport
                record.PlannedAltairport = parts[PLANNED_ALTAIRPORT_INDEX];
                // planned_remarks
                record.PlannedRemarks = parts[PLANNED_REMARKS_INDEX];
                // planned_route
                record.PlannedRoute = parts[PLANNED_ROUTE_INDEX];
                // planned_depairport_lat
                record.PlannedDepairportLat = parts[PLANNED_DEPAIRPORT_LAT_INDEX];
                // planned_depairport_lon
                record.PlannedDepairportLon = parts[PLANNED_DEPAIRPORT_LON_INDEX];
                // planned_destairport_lat
                record.PlannedDestairportLat = parts[PLANNED_DESTPAIRPORT_LAT_INDEX];
                // planned_destairport_lon
                record.PlannedDestairportLon = parts[PLANNED_DESTAIRPORT_LON_INDEX];
                // atis_message
                record.AtisMessage = parts[ATIS_MESSAGE_INDEX];
                // time_last_atis_received
                record.TimeLastAtisReceived = parts[TIME_LAST_ATIS_RECEIVED_INDEX];
                // time_logon
                record.TimeLogon = parts[TIME_LOGON_INDEX];
                // heading
                record.Heading = parts[HEADING_INDEX];
                // QNH_iHg
                record.QNH_iHg = parts[QNH_IHG_INDEX];
                // QNH_Mb
                record.QNH_Mb = parts[QNH_MB_INDEX];

            }

            return record;

        }

        public override string ToString()
        {

            string output = "";

            // callsign:
            output += $"Callsign: {this.Callsign}";
            output += Environment.NewLine;
            
            // cid:
            output += $"CID: {this.Cid}";            
            output += Environment.NewLine;            
            
            // realname:
            output += $"Real Name: {this.Realname}";
            output += Environment.NewLine;            
            
            // clienttype:
            output += $"Client Type: {this.Clienttype}";
            output += Environment.NewLine;            
            
            // frequency:
            output += $"Frequency: {this.Frequency}";
            output += Environment.NewLine;            
            
            // latitude:
            output += $"Latitude: {this.Latitude}";
            output += Environment.NewLine;            
            
            // longitude:
            output += $"Longitude: {this.Longitude}";
            output += Environment.NewLine;            
            
            // altitude:
            output += $"Altitude: {this.Altitude}";
            output += Environment.NewLine;            
            
            // groundspeed:
            output += $"Ground Speed: {this.Groundspeed}";
            output += Environment.NewLine;            
            
            // planned_aircraft:
            output += $"Planned Aircraft: {this.PlannedAircraft}";
            output += Environment.NewLine;            
            
            // planned_tascruise:
            output += $"Planned TAS Cruise: {this.PlannedTascruise}";
            output += Environment.NewLine;            
            
            // planned_depairport:
            output += $"Planned Departure Airport: {this.PlannedDepairport}";
            output += Environment.NewLine;            
            
            // planned_altitude:
            output += $"Planned Cruise Altitude: {this.PlannedAltitude}";
            output += Environment.NewLine;            
            
            // planned_destairport:
            output += $"Planned Destination Airport: {this.PlannedDestairport}";
            output += Environment.NewLine;            
            
            // server:
            output += $"Server: {this.Server}";
            output += Environment.NewLine;            
            
            // protrevision:
            output += $"Prot Revision: {this.Protrevision}";
            output += Environment.NewLine;            
            
            // rating:
            output += $"Rating: {this.Rating}";
            output += Environment.NewLine;            
            
            // transponder:
            output += $"Transponder: {this.Transponder}";
            output += Environment.NewLine;            
            
            // facilitytype:
            output += $"Facility Type: {this.Facilitytype}";
            output += Environment.NewLine;            
            
            // visualrange:
            output += $"Visual Range: {this.Visualrange}";
            output += Environment.NewLine;            
            
            // planned_revision:
            output += $"Planned Revision: {this.PlannedRevision}";
            output += Environment.NewLine;            
            
            // planned_flighttype:
            output += $"Planned Flight Type: {this.PlannedFlighttype}";
            output += Environment.NewLine;            
            
            // planned_deptime:
            output += $"Planned Departure Time: {this.PlannedDeptime}";
            output += Environment.NewLine;            
            
            // planned_actdeptime:
            output += $"Planned Actual Departure Time: {this.PlannedActdeptime}";
            output += Environment.NewLine;            
            
            // planned_hrsenroute:
            output += $"Planned Hours Enroute: {this.PlannedHrsenroute}";
            output += Environment.NewLine;            
            
            // planned_minenroute:
            output += $"Planned Minutes Enroute: {this.PlannedMinenroute}";
            output += Environment.NewLine;            
            
            // planned_hrsfuel:
            output += $"Planned Hours of Fuel: {this.PlannedHrsfuel}";
            output += Environment.NewLine;            
            
            // planned_minfuel:
            output += $"Planned Minutes of Fuel: {this.PlannedMinfuel}";
            output += Environment.NewLine;            
            
            // planned_altairport:
            output += $"Planned Alternate Airport: {this.PlannedAltairport}";
            output += Environment.NewLine;            
            
            // planned_remarks:
            output += $"Planned Remarks: {this.PlannedRemarks}";
            output += Environment.NewLine;            
            
            // planned_route:
            output += $"Planned Route: {this.PlannedRoute}";
            output += Environment.NewLine;            
            
            // planned_depairport_lat:
            output += $"Planned Departure Airport Latitude: {this.PlannedDepairportLat}";
            output += Environment.NewLine;            
            
            // planned_depairport_lon:
            output += $"Planned Departure Airport Longitude: {this.PlannedDepairportLon}";
            output += Environment.NewLine;            
            
            // planned_destairport_lat:
            output += $"Planned Destination Airport Latitude: {this.PlannedDestairportLat}";
            output += Environment.NewLine;            
            
            // planned_destairport_lon:
            output += $"Planned Destination Airport Longitude: {this.PlannedDestairportLon}";
            output += Environment.NewLine;            
            
            // atis_message:
            output += $"ATIS Message: {this.AtisMessage}";
            output += Environment.NewLine;            
            
            // time_last_atis_received:
            output += $"Time Last ATIS Received: {this.TimeLastAtisReceived}";
            output += Environment.NewLine;            
            
            // time_logon:
            output += $"Time Logon: {this.TimeLogon}";
            output += Environment.NewLine;            
            
            // heading:
            output += $"Heading: {this.Heading}";
            output += Environment.NewLine;            
            
            // QNH_iHg:
            output += $"QNH inches of mercury: {this.QNH_iHg}";
            output += Environment.NewLine;            
            
            // QNH_Mb:
            output += $"QNH Millibars: {this.QNH_Mb}";
            output += Environment.NewLine;            

            return output;
        }

        public VatsimClientATCV1 GetVatsimClientATCFromRecord()
        {
            VatsimClientATCV1 atc = new VatsimClientATCV1();

            atc.Callsign = this.Callsign;
            atc.Cid = this.Cid;
            atc.Clienttype = this.Clienttype;
            atc.Facilitytype = this.Facilitytype;
            atc.Frequency = this.Frequency;
            atc.Latitude = this.Latitude;
            atc.Longitude = this.Longitude;
            atc.Protrevision = this.Protrevision;
            atc.Rating = this.Rating;
            atc.Realname = this.Realname;
            atc.Server = this.Server;
            atc.TimeLastAtisReceived = this.TimeLastAtisReceived;
            atc.TimeLogon = this.TimeLogon;
            atc.Visualrange = this.Visualrange;
            
            return atc;
        }

        public VatsimClientPilotV1 GetVatsimClientPilotFromRecord()
        {
            VatsimClientPilotV1 pilot = new VatsimClientPilotV1();

            pilot.Callsign = this.Callsign;
            pilot.Cid = this.Cid;
            pilot.Clienttype = this.Clienttype;
            pilot.Latitude = this.Latitude;
            pilot.Longitude = this.Longitude;
            pilot.Realname = this.Realname;
            pilot.Protrevision = this.Protrevision;
            pilot.Server = this.Server;
            pilot.TimeLastAtisReceived = this.TimeLastAtisReceived;
            pilot.TimeLogon = this.TimeLogon;

            return pilot;
        }

        public VatsimClientPlannedFlightV1 GetVatsimClientPlannedFlightFromRecord()
        {
            VatsimClientPlannedFlightV1 flight = new VatsimClientPlannedFlightV1();

            flight.Callsign = this.Callsign;
            flight.Cid = this.Cid;
            flight.Clienttype = this.Clienttype;
            flight.Latitude =  this.Latitude;
            flight.Longitude = this.Longitude;
            flight.PlannedActdeptime = this.PlannedActdeptime;
            flight.PlannedAircraft = this.PlannedAircraft;
            flight.PlannedAltairport = this.PlannedAltairport;
            flight.PlannedAltitude = this.PlannedAltitude;
            flight.PlannedDepairport = this.PlannedDepairport;
            flight.PlannedDepairportLat = this.PlannedDepairportLat;
            flight.PlannedDepairportLon = this.PlannedDepairportLon;
            flight.PlannedDeptime = this.PlannedDeptime;
            flight.PlannedDestairport = this.PlannedDestairport;
            flight.PlannedDestairportLat = this.PlannedDestairportLat;
            flight.PlannedDestairportLon = this.PlannedDestairportLon;
            flight.PlannedFlighttype = this.PlannedFlighttype;
            flight.PlannedHrsenroute = this.PlannedHrsenroute;
            flight.PlannedHrsfuel = this.PlannedHrsfuel;
            flight.PlannedMinenroute = this.PlannedMinenroute;
            flight.PlannedMinfuel = this.PlannedMinfuel;
            flight.PlannedRemarks = this.PlannedRemarks;
            flight.PlannedRevision = this.PlannedRevision;
            flight.PlannedRoute = this.PlannedRoute;
            flight.PlannedTascruise = this.PlannedTascruise;
            flight.Protrevision = this.Protrevision;
            flight.Realname = this.Realname;
            flight.Server = this.Server;
            flight.TimeLastAtisReceived = this.TimeLastAtisReceived;
            flight.TimeLogon = this.TimeLogon;

            return flight;
        }

        public VatsimClientPilotSnapshotV1 GetVatsimClientPilotSnapshotFromRecord()
        {
            VatsimClientPilotSnapshotV1 position = new VatsimClientPilotSnapshotV1();

            position.Altitude = this.Altitude;
            position.Callsign = this.Callsign;
            position.Cid = this.Cid;
            position.Clienttype = this.Clienttype;
            position.Groundspeed = this.Groundspeed;
            position.Heading = this.Heading;
            position.Latitude = this.Latitude;
            position.Longitude = this.Longitude;
            position.Protrevision = this.Protrevision;
            position.QNH_iHg = this.QNH_iHg;
            position.QNH_Mb = this.QNH_Mb;
            position.Realname = this.Realname;
            position.Server = this.Server;
            position.TimeLastAtisReceived = this.TimeLastAtisReceived;
            position.TimeLogon = this.TimeLogon;
            position.TimeStamp = DateTime.Now;
            position.Transponder = this.Transponder;

            return position;
        }
    }
}
