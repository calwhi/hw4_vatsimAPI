using System;

namespace VatsimLibrary.VatsimData
{
    public class VatsimAircraft
    {
        public int ID {get; set;}
        public string ICAO {get; set;}
        public string Name {get; set;}

        public static void LoadTypesIntoDb(string dbname)
        {

        }        
    }
}