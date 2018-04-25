using System;
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
                .WriteTo.Console()
                .WriteTo.Seq("http://seq:5341/")
                .WriteTo.EventCollector("http://splunk:8088/","00112233-4455-6677-8899-AABBCCDDEEFF")
                .Enrich.WithProperty("App Name", "Serilog Console Docker Sample")
                .CreateLogger();

            Log.Information("Starting Serilog Console Sample");
            
            Go(Log.Logger).Wait();
            
         }
         
         private static async Task Go(ILogger logger)
         {
            while (true)
            {
                logger.Information("Serilog Console checking Web Sample at http://websample:5000"); 
                 
                try
                {
                    using (var client = new HttpClient())
                    using (var response = await client.GetAsync("http://websample:5000"))
                    using (var content = response.Content)
                    { 
                        string result = await content.ReadAsStringAsync();
                        logger.Information(result);
                    }
                }
                catch (System.Exception ex)
                {
                    logger.Error(ex, "An error occured for HTTP GET to http://websample:5000");
                }
                
                logger.Information("Serilog Console checking F# Web Sample at http://fswebsample:5001"); 
                try
                {
                    using (var client = new HttpClient())
                    using (var response = await client.GetAsync("http://fswebsample:5001"))
                    using (var content = response.Content)
                    { 
                        string result = await content.ReadAsStringAsync();
                        logger.Information(result);
                    }
                }
                catch (System.Exception ex)
                {
                    logger.Error(ex, "An error occured for HTTP GET to http://fswebsample:5001");
                }
           
                await Task.Delay(3000); 
            }
         }
    }
}
