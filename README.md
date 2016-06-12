# serilog-docker
A docker image for testing Serilog on *nix platforms.  Also some sample apps.

[![SerilogCast](https://asciinema.org/a/47600.png)](https://asciinema.org/a/47600)

## PreReqs

* Docker (easiest with [Docker Toolbox](https://www.docker.com/products/docker-toolbox) or [Docker Beta](https://beta.docker.com/))

## Serilog
- Clone this repo.
- Run `docker-compose up` .  This will 
    * pull the images
    * pull the Serilog repo, 
    * build and test the lastest `dev` branch code from https://github.com/serilog/serilog.

### Example Output

```
Building serilog
Step 1 : FROM microsoft/dotnet
 ---> xxxxx
Step 2 : ENV SERILOG_BRANCH dev
....
Successfully built xxxxxxxxxx
....
serilog_1  | Compiling Serilog for .NETStandard,Version=v1.0
serilog_1  |
serilog_1  | Compilation succeeded.
serilog_1  |     0 Warning(s)
serilog_1  |     0 Error(s)
serilog_1  |
serilog_1  | Time elapsed 00:00:09.7822686
....
serilog_1  | Project Serilog (.NETStandard,Version=v1.3) was previously compiled. Skipping compilation.
serilog_1  | Project TestDummies (.NETStandard,Version=v1.2) was previously compiled. Skipping compilation.
serilog_1  | Project Serilog.Tests (.NETCoreApp,Version=v1.0) was previously compiled. Skipping compilation.
serilog_1  | xUnit.net .NET CLI test runner (64-bit debian.8-x64)
serilog_1  |   Discovering: Serilog.Tests
serilog_1  |   Discovered:  Serilog.Tests
serilog_1  |   Starting:    Serilog.Tests
serilog_1  |   Finished:    Serilog.Tests
serilog_1  | === TEST EXECUTION SUMMARY ===
serilog_1  |    Serilog.Tests  Total: 176, Errors: 0, Failed: 0, Skipped: 0, Time: 2.955s
serilogdocker_serilog_1 exited with code 0
```

## Run the Samples

This repo also contains the following samples

* Console App
* Web App
* FSharp Web App

To run these, run `docker-compose -f samples.yml up`

This will build & run the samples. The console app periodically does a HTTP GET to the sample web apps. Both are configured to use Serilog and `Serilog.Extensions.Logging`.   

### Example Output

``` 
consoleapp_1  | Compilation succeeded.
websample_1   | Compilation succeeded.
consoleapp_1  |     0 Error(s)
consoleapp_1  |
consoleapp_1  | Time elapsed 00:00:12.6793659
consoleapp_1  | 
consoleapp_1  | [23:28:48 INF] Starting Serilog Console Sample
consoleapp_1  | [23:28:48 INF] Serilog Console checking Web Sample at http://websample:5000
consoleapp_1  | [23:28:48 ERR] An error occured for HTTP GET to http://websample:5000
consoleapp_1  | System.Net.Http.HttpRequestException: An error occurred while sending the request. ---> System.Net.Http.CurlException: Couldn't connect to server
consoleapp_1  |    at System.Net.Http.CurlHandler.ThrowIfCURLEError(CURLcode error)
consoleapp_1  |    at System.Net.Http.CurlHandler.MultiAgent.FinishRequest(EasyRequest completedOperation, CURLcode messageResult)
consoleapp_1  |    --- End of inner exception stack trace ---
consoleapp_1  |    at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
consoleapp_1  |    at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
consoleapp_1  |    at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
consoleapp_1  |    at Sample.Program.<Go>d__1.MoveNext() 
websample_1   |
websample_1   | [23:28:53 DBG] Hosting starting
websample_1   | [23:28:53 DBG] Hosting started
websample_1   | Hosting environment: Production
websample_1   | Content root path: /sample/bin/Debug/netcoreapp1.0
websample_1   | Now listening on: http://0.0.0.0:5000
websample_1   | Application started. Press Ctrl+C to shut down.
consoleapp_1  | [23:28:54 INF] Serilog Console checking Web Sample at http://websample:5000
websample_1   | [23:28:54 DBG] Connection id "0HKS3C80P1TVR" started.
websample_1   | [23:28:54 INF] Request starting HTTP/1.1 GET http://websample:5000/
websample_1   | [23:28:54 INF] Request finished in 82.8688ms 200
websample_1   | [23:28:54 DBG] Connection id "0HKS3C80P1TVR" completed keep alive response.
consoleapp_1  | [23:28:54 INF] Hello from Serilog ASP.NET Core Sample!
websample_1   | [23:28:55 DBG] Connection id "0HKS3C80P1TVR" received FIN.
websample_1   | [23:28:55 DBG] Connection id "0HKS3C80P1TVR" disconnecting.
websample_1   | [23:28:55 DBG] Connection id "0HKS3C80P1TVR" sending FIN.
websample_1   | [23:28:55 DBG] Connection id "0HKS3C80P1TVR" sent FIN with status "0".
websample_1   | [23:28:55 DBG] Connection id "0HKS3C80P1TVR" stopped.
consoleapp_1  | [23:28:57 INF] Serilog Console checking Web Sample at http://websample:5000 
```
