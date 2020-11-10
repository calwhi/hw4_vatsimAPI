using System;

using VatsimLibrary.VatsimData;

namespace VatsimLibrary.VatsimClientV1
{

    public class VatsimClientATCV1 : VatsimClientV1
    {
        public string AtisMessage { get; set; }                
        public string Frequency { get; set; }
        public string Facilitytype { get; set; }
        public string Rating { get; set; }        
        public string Visualrange { get; set; }

        public void Update(VatsimClientATCV1 controller)
        {
            this.Cid = controller.Cid;
            this.Callsign = controller.Callsign;
            this.AtisMessage = controller.AtisMessage;
            this.Clienttype = controller.Clienttype;
            this.Facilitytype = controller.Facilitytype;
            this.Frequency = controller.Frequency;
            this.Latitude = controller.Latitude;
            this.Longitude = controller.Longitude;
            this.Protrevision = controller.Protrevision;
            this.Rating = controller.Rating;
            this.Realname = controller.Realname;
            this.Server = controller.Server;
            this.TimeLastAtisReceived = controller.TimeLastAtisReceived;
            this.TimeLogon = controller.TimeLogon;
            this.Visualrange = controller.Visualrange;
        }

        public override string ToString()
        {
            return $"{this.Cid} - {this.Callsign} - {this.Facilitytype} - {this.Frequency}";
        }

    }
}