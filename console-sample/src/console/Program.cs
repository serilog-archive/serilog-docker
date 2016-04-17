using System;
using Serilog;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .MinimumLevel.Debug()
                .CreateLogger();
            
            while (true)
            {
                Log.Debug ("Debug");
                Log.Information ("Info");
                Log.Warning ("Warning");
                Log.Error ("Error");
                 
                System.Threading.Tasks.Task.Delay(1000).Wait();
            }
        }
    }
}