using System;

namespace VatsimLibrary.VatsimClientV1
{
    public class VatsimClientPlannedFlightV1 : VatsimClientV1
    {
        public string PlannedAircraft { get; set; }
        public string PlannedAltitude { get; set; }        
        public string PlannedAltairport { get; set; }        
        public string PlannedDepairport { get; set; }
        public string PlannedDepairportLat { get; set; }
        public string PlannedDestairportLon { get; set; }        
        public string PlannedDestairport { get; set; }
        public string PlannedDepairportLon { get; set; }
        public string PlannedDestairportLat { get; set; }        
        public string PlannedFlighttype { get; set; }
        public string PlannedDeptime { get; set; }
        public string PlannedActdeptime { get; set; }
        public string PlannedHrsenroute { get; set; }
        public string PlannedMinenroute { get; set; }
        public string PlannedHrsfuel { get; set; }
        public string PlannedMinfuel { get; set; }
        public string PlannedRemarks { get; set; }
        public string PlannedRevision { get; set; }        
        public string PlannedRoute { get; set; }
        public string PlannedTascruise { get; set; }

        public void Update(VatsimClientPlannedFlightV1 flight)
        {
            this.Cid = flight.Cid;
            this.Callsign = flight.Callsign;
            this.Clienttype = flight.Clienttype;
            this.Latitude = flight.Latitude;
            this.Longitude = flight.Longitude;
            this.PlannedActdeptime = flight.PlannedActdeptime;
            this.PlannedAircraft = flight.PlannedAircraft;
            this.PlannedAltairport = flight.PlannedAltairport;
            this.PlannedAltitude = flight.PlannedAltitude;
            this.PlannedDepairport = flight.PlannedDepairport;
            this.PlannedDepairportLat = flight.PlannedDepairportLat;
            this.PlannedDepairportLon = flight.PlannedDepairportLon;
            this.PlannedDeptime = flight.PlannedDeptime;
            this.PlannedDestairport = flight.PlannedDestairport;
            this.PlannedDestairportLat = flight.PlannedDestairportLat;
            this.PlannedDestairportLon = flight.PlannedDestairportLon;
            this.PlannedFlighttype = flight.PlannedFlighttype;
            this.PlannedHrsenroute = flight.PlannedHrsenroute;
            this.PlannedHrsfuel = flight.PlannedHrsfuel;
            this.PlannedMinenroute = flight.PlannedMinenroute;
            this.PlannedMinfuel = flight.PlannedMinfuel;
            this.PlannedRemarks = flight.PlannedRemarks;
            this.PlannedRevision = flight.PlannedRevision;
            this.PlannedRoute = flight.PlannedRoute;
            this.PlannedTascruise = flight.PlannedTascruise;
            this.Protrevision = flight.Protrevision;
            this.Realname = flight.Realname;
            this.Server = flight.Server;
            this.TimeLastAtisReceived = flight.TimeLastAtisReceived;
            this.TimeLogon = flight.TimeLogon;
        }

        public override string ToString()
        {
            return $"{this.Cid} - {this.Callsign} - {this.PlannedDepairport} - {this.PlannedDestairport}";
        }
    }
}