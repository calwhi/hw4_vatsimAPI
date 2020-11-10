using System;
using System.Collections.Generic;

using VatsimLibrary.VatsimData;

namespace VatsimLibrary.VatsimClientV1
{
    public class VatsimClientPilotV1 : VatsimClientV1
    {
        public void Update(VatsimClientPilotV1 pilot)
        {
            this.Callsign = pilot.Callsign;
            this.Cid = pilot.Cid;
            this.Clienttype = pilot.Clienttype;
            this.Latitude = pilot.Latitude;
            this.Longitude = pilot.Longitude;
            this.Protrevision = pilot.Protrevision;
            this.Realname = pilot.Realname;
            this.Server = pilot.Server;
            this.TimeLastAtisReceived = pilot.TimeLastAtisReceived;
            this.TimeLogon = pilot.TimeLogon;
        }

        public override string ToString()
        {
            return $"{this.Cid} - {this.Callsign} - {this.Realname}";
        }
    }
}