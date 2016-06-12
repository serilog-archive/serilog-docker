namespace Sample

// Adapted from https://github.com/Krzysztof-Cieslak/KestrelFSharp.git
module Main = 
    open System
    open System.IO
    open System.Text
    open System.Threading.Tasks
    open Microsoft.AspNetCore.Builder
    open Microsoft.AspNetCore.Http
    open Microsoft.AspNetCore.Http.Extensions
    open Microsoft.AspNetCore.Hosting
    open Serilog
    open Serilog.Configuration
    open Microsoft.Extensions.Logging
    open Microsoft.Extensions.Configuration
    open Microsoft.AspNetCore.Builder

    type Startup (env: IHostingEnvironment) =
        do
            Log.Logger <- LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .WriteTo.LiterateConsole()
                            .Enrich.FromLogContext() 
                            .CreateLogger();

        member this.Configuration
            with get() = Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource(
                            InitialData = (dict [ "Logging:IncludeScopes", "False"
                                                  "Logging:LogLevel:System", "Warning"
                                                  "Logging:LogLevel:Default", "Debug"
                                                  "Logging:LogLevel:Microsoft", "Warning" ]))

        member this.Configure (app : IApplicationBuilder, env: IHostingEnvironment, loggerFactory: ILoggerFactory) =
            loggerFactory.AddSerilog() |> ignore

            app.Run (fun ctx ->
                let log = ctx.RequestServices.GetService(typeof<ILogger<unit>>) :?> ILogger<unit>
                log.LogDebug("got request at {@requestUrl}", ctx.Request.GetEncodedUrl())
                
                sprintf "Hello from Serilog ASP.NET Core F# Sample!"
                |> ctx.Response.WriteAsync
            )
 
    [<EntryPoint>]
    let main argv = 
        WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseUrls("http://0.0.0.0:5001")
            .UseStartup<Startup>()
            .Build()
            .Run()
        
        0 // return an integer exit code