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

        //CALEB L WHITE
        //1030708 WTAMU ID
        //11/10/2020

        public static async Task AltitudeEndpoint(HttpContext context)
        {
            string pilotAltCS = context.Request.RouteValues["alt"] as string;

            using(var db = new VatsimDbContext())
            {
                if(pilotAltCS != null)
                {
                    Console.WriteLine($"Altitude requested for {pilotAltCS}");
                   
                    var _alt = await db.Positions.Where(f => f.Callsign.Contains((pilotAltCS ?? "").ToUpper())).ToListAsync();

                    await context.Response.WriteAsync($"*************** THERE ARE {_alt.Count()} RECORD(S) FOR {pilotAltCS} *******************          ");
                    
                    foreach (var item in _alt)
                    {
                        await context.Response.WriteAsync($"At {item.TimeStamp}, {item.Callsign} was at {item.Altitude}ft" + "      ");
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
            string pilotSpeedCS = context.Request.RouteValues["speed"] as string;

            using(var db = new VatsimDbContext())
            {
                if(pilotSpeedCS != null)
                {
                    Console.WriteLine($"Speed requested for {pilotSpeedCS}");
                   
                    var _spd = await db.Positions.Where(f => f.Callsign.Contains((pilotSpeedCS ?? "").ToUpper())).ToListAsync();

                    await context.Response.WriteAsync($"*************** THERE ARE {_spd.Count()} RECORD(S) FOR {pilotSpeedCS} *******************          ");
                    
                    foreach (var item in _spd)
                    {
                        await context.Response.WriteAsync($"At {item.TimeStamp}, {item.Callsign} was at {item.Groundspeed}knts" + "  ");
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
            string latCS = context.Request.RouteValues["lat"] as string;

            using(var db = new VatsimDbContext())
            {
                if(latCS != null)
                {
                    Console.WriteLine($"Latitude requested for {latCS}");
                   
                    var _lat = await db.Positions.Where(f => f.Callsign.Contains((latCS ?? "").ToUpper())).ToListAsync();

                    await context.Response.WriteAsync($"*************** THERE ARE {_lat.Count()} RECORD(S) FOR {latCS} *******************          ");
                    
                    foreach (var item in _lat)
                    {
                        await context.Response.WriteAsync($"At {item.TimeStamp}, {item.Callsign}'s latitude was {item.Latitude}*" + "  ");
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
            } 
        }

        public static async Task LongitudeEndpoint(HttpContext context)
        {
            string lonCS = context.Request.RouteValues["lon"] as string;

            using(var db = new VatsimDbContext())
            {
                if(lonCS != null)
                {
                    Console.WriteLine($"Longitude requested for {lonCS}");
                   
                    var _lon = await db.Positions.Where(f => f.Callsign.Contains((lonCS ?? "").ToUpper())).ToListAsync();

                    await context.Response.WriteAsync($"*************** THERE ARE {_lon.Count()} RECORD(S) FOR {lonCS} *******************          ");
                    
                    foreach (var item in _lon)
                    {
                        await context.Response.WriteAsync($"At {item.TimeStamp}, {item.Callsign}'s longitude was {item.Longitude}*" + "  ");
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }

            //CALEB L WHITE
            //1030708 WTAMU ID
            //11/10/2020
            } 
        }
    }
}