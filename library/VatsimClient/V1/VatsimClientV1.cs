using System;

namespace VatsimLibrary.VatsimClientV1
{
    public abstract class VatsimClientV1
    {
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

        public string Cid { get; set; }        
        public string Callsign { get; set; }
        public string Realname { get; set; }
        public string Clienttype { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Server { get; set; }
        public string Protrevision { get; set; }
        public string TimeLastAtisReceived { get; set; }
        public string TimeLogon { get; set; }
    }
}
