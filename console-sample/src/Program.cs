using System;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Sample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() 
                .WriteTo.LiterateConsole()
                .WriteTo.EventCollector("http://splunk:8088/services/collector","00112233-4455-6677-8899-AABBCCDDEEFF")
                .CreateLogger();

            Microsoft.Extensions.Logging.ILogger logger = new LoggerFactory()
                .AddSerilog()
                .CreateLogger(typeof(Program).FullName);

            logger.LogInformation("Starting Serilog Console Sample");
            
            Go(logger).Wait();
            
         }
         
         private static async Task Go(Microsoft.Extensions.Logging.ILogger logger)
         {
            while (true)
            {
                Log.Information("Serilog Console checking Web Sample at http://websample:5000"); 
                 
                try
                {
                    using (var client = new HttpClient())
                    using (var response = await client.GetAsync("http://websample:5000"))
                    using (var content = response.Content)
                    { 
                        string result = await content.ReadAsStringAsync();
                        logger.LogInformation(result);
                    }
                }
                catch (System.Exception ex)
                {
                    Log.Error(ex, "An error occured for HTTP GET to http://websample:5000");
                }
                
                Log.Information("Serilog Console checking F# Web Sample at http://fswebsample:5001"); 
                try
                {
                    using (var client = new HttpClient())
                    using (var response = await client.GetAsync("http://fswebsample:5001"))
                    using (var content = response.Content)
                    { 
                        string result = await content.ReadAsStringAsync();
                        logger.LogInformation(result);
                    }
                }
                catch (System.Exception ex)
                {
                    Log.Error(ex, "An error occured for HTTP GET to http://fswebsample:5001");
                }
           
                await Task.Delay(3000); 
            }
         }
    }
}
