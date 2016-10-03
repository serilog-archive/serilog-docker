using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:5000")
                .Build(); 

            host.Run();
        }
    }
}