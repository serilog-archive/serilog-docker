namespace FSharpKestrelSample

open System.IO
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Serilog

module Program =
    let successExitCode = 0
    let failureExitCode = 1

    let Configuration =
        ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional=true, reloadOnChange=true)
            .Build() :> IConfiguration

    let CreateWebHostBuilder args =
        WebHost
            .CreateDefaultBuilder(args)
            .UseSerilog()
            .UseStartup<Startup>();

    [<EntryPoint>]
    let main args =

        Log.Logger <- LoggerConfiguration()
            .ReadFrom.Configuration(Configuration)
            .Enrich.WithProperty("App Name", "Serilog F# Kestrel Sample")
            .CreateLogger()

        Log.Information("Starting with arguments {Args}", args)

        try
            try
                CreateWebHostBuilder(args).Build().Run()
                successExitCode
            with
            | ex ->
                Log.Fatal(ex, "Host terminated unexpectedly")
                failureExitCode
        finally
            Log.Information("Shutting down")
            Log.CloseAndFlush()
