using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;

namespace api
{
    public class PilotsEndpoint
    {
        public static async Task CallsignEndpoint(HttpContext context)
        {
            string responseText = null;
            string callsign = context.Request.RouteValues["callsign"] as string;
            switch((callsign ?? "").ToLower())
            {
                case "aal1":
                    responseText = "Callsign: AAL1";
                    break;
                default:
                    responseText = "Callsign: INVALID";
                    break;
            }

            if(callsign != null)
            {
                await context.Response.WriteAsync($"{responseText} is the callsign");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }


        /* NOTE: All of these require that you first obtain a pilot and then search in Positions */

        public static async Task AltitudeEndpoint(HttpContext context)
        {
            string pilotAlt = context.Request.RouteValues["alt"] as string;

            using(var db = new VatsimDbContext())
            {
                if(pilotAlt != null)
                {
                    Console.WriteLine($"{pilotAlt}");
                   
                    var _alt = await db.Positions.Where(f => f.Altitude.Contains((pilotAlt ?? "").ToUpper())).ToListAsync();
                    
                    foreach (var item in _alt)
                    {
                        await context.Response.WriteAsync($"Callsign {item.Callsign} is at {item.Altitude}ft" + "      ");
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
            }  
        }

        public static async Task GroundspeedEndpoint(HttpContext context)
        {
            string pilotSpeed = context.Request.RouteValues["speed"] as string;

            using(var db = new VatsimDbContext())
            {
                if(pilotSpeed != null)
                {
                    Console.WriteLine($"{pilotSpeed}");
                   
                    var _spd = await db.Positions.Where(f => f.Groundspeed.Contains((pilotSpeed ?? "").ToUpper())).ToListAsync();
                    
                    foreach (var item in _spd)
                    {
                        await context.Response.WriteAsync($"Callsign {item.Callsign} is at {item.Groundspeed}knts" + "      ");
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
            } 
        }

        public static async Task LatitudeEndpoint(HttpContext context)        
        {
            //TO DO
            await context.Response.WriteAsync($"PLEASE IMPLEMENT ME");
        }

        public static async Task LongitudeEndpoint(HttpContext context)
        {
            //TO DO
            await context.Response.WriteAsync($"PLEASE IMPLEMENT ME");
        }
    }
}