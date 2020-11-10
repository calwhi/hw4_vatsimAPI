using System;
using System.Linq;

using VatsimLibrary.VatsimDb;

namespace hw
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"{VatsimDbHelper.DATA_DIR}");

            using(var db = new VatsimDbContext())
            {

                Console.WriteLine($"The number of pilots records is: {db.Pilots.Count()} ");

                //find A319
                var _aircraft = db.Flights.Where(f => f.PlannedAircraft.Contains("A319"));
                Console.WriteLine($"It is likely that there are {_aircraft.Count()} A319s in the data");

                _aircraft = db.Flights.Where(f => f.PlannedAircraft.Contains("B738"));
                Console.WriteLine($"It is likely that there are {_aircraft.Count()} B738s in the data");

                var _depList = db.Flights.ToList();

                //departure most
                 var _dep = _depList.GroupBy(f => f.PlannedDepairport).OrderByDescending(g => g.Count());

                Console.WriteLine($"{_dep.ElementAt(0).Key} - {_dep.ElementAt(0).Count()}");

                // foreach(var flight in _dep)
                // {
                //     Console.WriteLine($"{flight.Key} - {flight.Count()}");
                // }
            }            
        }

        public static void FindPilot(VatsimDbContext db, string cid, string callsign, string logontime)
        {
            var _pilot = db.Pilots.Find(cid, callsign, logontime);
            if(_pilot != null){
                Console.WriteLine($"Pilot found: {_pilot.Realname}");
            } else {
                Console.WriteLine("Pilot not found");
            }            
        }
    }
}
