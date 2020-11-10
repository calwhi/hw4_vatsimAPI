using System;

namespace VatsimLibrary.VatsimClientV1
{
    public class VatsimClientPilotSnapshotV1 : VatsimClientV1
    {
        public DateTime TimeStamp { get; set; }
        public string Altitude { get; set; }
        public string Groundspeed { get; set; }
        public string Transponder { get; set; }
        public string Heading { get; set; }
        public string QNH_iHg { get; set; }
        public string QNH_Mb { get; set; }

        public override string ToString()
        {
            return $"{this.Cid} - {this.Callsign} - {this.Latitude} - {this.Longitude}";
        }

    }
}