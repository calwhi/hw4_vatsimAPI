using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Serilog;

using VatsimLibrary.VatsimUtils;

// reference on HttpClient: http://zetcode.com/csharp/httpclient/
namespace VatsimLibrary.VatsimData
{
    public class VatsimDataReader
    {

        public static readonly char COMMENT_CHARACTER = ';';

        public static readonly string VATSIM_LOCAL_DATA_DIRECTORY = 
                                      Environment.CurrentDirectory + 
                                      Path.DirectorySeparatorChar + 
                                      "data";

        public static readonly string VATSIM_LOCAL_DATA_FILE =
                                      VATSIM_LOCAL_DATA_DIRECTORY +
                                      Path.DirectorySeparatorChar +                                                               
                                      "vatsim-data.txt";

        public static readonly string VATSIM_LOCAL_SERVER_FILE = 
                                      VATSIM_LOCAL_DATA_DIRECTORY +
                                      Path.DirectorySeparatorChar +                                                               
                                      "vatsim-servers.txt";

        public static readonly string[] IgnoreStartsWithList = new string[]
        {
            COMMENT_CHARACTER.ToString(),
            "!GENERAL",
            "VERSION",
            "RELOAD",
            "UPDATE",
            "CONNECTED CLIENTS",
            "UNIQUE USERS",
        };

        public static readonly string VATSIM_STATUS_URL;
        public static readonly string VATSIM_DATA_PREFIX;
        public static readonly string VATSIM_SERVERS_PREFIX;
        public static readonly string VATSIM_METAR_PREFIX;

        public static VatsimDataState CurrentVatsimData {get; set;}

        //static constructor
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors    
        static VatsimDataReader()
        {
            /*
                url0 - URLs where complete data files are available. Please choose one randomly every time
                url1 - URLs where servers list data files are available. Please choose one randomly every time
                metar0 - URL where to retrieve metar. Invoke it passing a parameter like for example: http://data.satita.net/metar.html?id=KBOS
            */
            VATSIM_STATUS_URL = "https://status.vatsim.net/";
            VATSIM_DATA_PREFIX = "url0";            
            VATSIM_SERVERS_PREFIX = "url1";            
            VATSIM_METAR_PREFIX = "metar0";

            CurrentVatsimData = new VatsimDataState();

        }

        public static void EnsureDataDirectoryExists(string dir)
        {
            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        /// <summary>
        /// Read https://status.vatsim.net to parse the most current URLs needed to
        /// Access client and server data from VATSIM.
        /// </summary>
        /// <returns>Async Task</returns>
        private async static Task GetVatsimURLS()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync(VATSIM_STATUS_URL);

            string[] parts = result.Split(Environment.NewLine.ToCharArray());

            foreach (string part in parts)
            {
                if(part.StartsWith(VATSIM_DATA_PREFIX)){
                    CurrentVatsimData.VatsimDataUrl = part.Split('=')[1];
                } else if(part.StartsWith(VATSIM_SERVERS_PREFIX)){
                    CurrentVatsimData.VatsimServersUrl = part.Split('=')[1];
                } else if(part.StartsWith(VATSIM_METAR_PREFIX)){
                    CurrentVatsimData.VatsimMetarUrl = part.Split('=')[1];
                }
            }

            // Console.WriteLine($"data url: {CurrentVatsimData.VatsimDataUrl}");
            // Console.WriteLine($"servers url: {CurrentVatsimData.VatsimServersUrl}");
            // Console.WriteLine($"metar url: {CurrentVatsimData.VatsimMetarUrl}"); 

        }        

        /// <summary>
        /// Get Vatsim Client Data Records from the status.vatsim.net server in the vatsim-data.txt file
        /// </summary>
        /// <param name="filename">file to read</param>
        /// <returns>Async task that reutrns a List of VatsimCliendRecords</returns>
        public static void GetVatsimClientRecordsFromLocalFile(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);

                // get clients
                GetVatsimClientRecordsFromLines(lines);

                // metadata
                GetVatsimDataMetaDataFromLines(lines);

            }
            catch(Exception exp)
            {
                Console.Error.WriteLine($"DUDE:\nMessage: {exp.Message}\nStackTrace: {exp.StackTrace}");
            }
        }        

        private static void GetVatsimClientRecordsFromLines(string[] lines)
        {

            bool client_section = false;

            Console.Write("Processing Vatsim Client Records from File... ");
            using (var progress = new ConsoleProgressBar())
            {
                int count = 0;
                int total = lines.Length;
                foreach(string line in lines)
                {
                    if(!IgnoreThisLine(line))
                    {
                        
                        progress.Report((double)count++ / total);
                        Thread.Sleep(20);

                        if(line.StartsWith("!CLIENTS:"))
                        {
                            client_section = true;
                            continue;
                        } 
                        if(line.StartsWith("!SERVERS:") || line.StartsWith("!PREFILE:"))
                        {
                            client_section = false;
                            return;
                        }
                        if(client_section)
                        {
                            CurrentVatsimData.VatsimClientRecords.Add(VatsimClientRecord.GetVatsimClientRecord(line));              
                        }
                    }
                }    
            }
            Console.WriteLine("Done.");
        }        

        /// <summary>
        /// Given lines from the vatsim-data.txt file, parse metadata information
        /// </summary>
        /// <param name="lines">lines from vatsim-data.txt</param>
        /// <param name="currentData">VatsimData</param>
        private static void GetVatsimDataMetaDataFromLines(string[] lines)
        {
            // get meta data
            foreach(string line in lines)
            {

                if(line.StartsWith("VERSION"))
                {
                    CurrentVatsimData.VatsimDataVersion = line.Split('=')[1].Trim();
                }
                if(line.StartsWith("RELOAD"))
                {
                    CurrentVatsimData.VatsimDataReload = line.Split('=')[1].Trim();
                }
                if(line.StartsWith("UPDATE"))
                {
                    string update_value = line.Split('=')[1].Trim();
                    CurrentVatsimData.VatsimDataLastUpdated = VatsimDataState.GetDateTimeFromVatsimTimeStamp(update_value);
                }
                if(line.StartsWith("CONNECTED CLIENTS"))
                {
                    CurrentVatsimData.VatsimDataConnectedClients = line.Split('=')[1].Trim();
                }
                if(line.StartsWith("UNIQUE USERS"))
                {
                    CurrentVatsimData.VatsimDataUniqueUsers = line.Split('=')[1].Trim();
                }
            }
        }        

        /// <summary>
        /// Ignore comment character in the given line of vatsim-data
        /// </summary>
        /// <param name="line">vatsim-data record</param>
        /// <returns>T/F to ignore</returns>
        public static bool IgnoreThisLine(string line)
        {
            bool ignore = false;

            foreach (string reject in IgnoreStartsWithList)
            {
                if (line.StartsWith(reject))
                {
                    ignore = true;
                    return ignore;
                }
            }

            return ignore;
        }        

        /// <summary>
        /// Processes Vatsim Clients and Servers
        /// </summary>
        /// <returns>Async Task</returns>
        public async static Task ProcessVatsimData()
        {

            //remove all records
            CurrentVatsimData.VatsimClientRecords.Clear();

            // Console.WriteLine($"Length: {CurrentVatsimData.VatsimClientRecords.Count}");

            //get urls
            await GetVatsimURLS();

            //read clients
            EnsureDataDirectoryExists(VATSIM_LOCAL_DATA_DIRECTORY);
            var data_result = await WriteVatsimDataToFileAsync(CurrentVatsimData.VatsimDataUrl, 
                                                               VATSIM_LOCAL_DATA_FILE);

            if(data_result)
            {
                GetVatsimClientRecordsFromLocalFile(VATSIM_LOCAL_DATA_FILE);
                string message = $"{CurrentVatsimData.VatsimClientRecords.Count} client records were created";
                Log.Information(message);
                Console.WriteLine(message);
            }

            //read servers            
            var server_result = await WriteVatsimDataToFileAsync(CurrentVatsimData.VatsimServersUrl, 
                                                                 VATSIM_LOCAL_SERVER_FILE);

            if(server_result)
            {
                // TODO process vatsim servers file
            }
        }

        /// <summary>
        /// Write Vatsim Data file to local disk
        /// Reference: https://www.csharpcodi.com/csharp-examples/System.Net.Http.HttpClient.GetStreamAsync(System.Uri)/
        /// </summary>
        /// <param name="uri">Vatsim data text file url</param>
        /// <param name="filename">Loval data text file location</param>
        /// <returns>Async bool</returns>
        private static async Task<bool> WriteVatsimDataToFileAsync(string uri, string filename)
        {
            try 
            {
                using (var fileStream = File.Open(filename, FileMode.Create))
                {
                    var webStream = await new HttpClient().GetStreamAsync(uri);
                    await webStream.CopyToAsync(fileStream);
                    webStream.Dispose();
                }
            }
            catch(Exception exp)
            {
                Console.Error.WriteLine(exp.Message);
            }

            return File.Exists(filename);
        }
    }
}