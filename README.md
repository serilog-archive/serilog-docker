# serilog-docker
A docker image for testing Serilog on *nix platforms.  Also some sample apps.

[![SerilogCast](https://asciinema.org/a/47600.png)](https://asciinema.org/a/47600)

## PreReqs

* Docker (easiest with [Docker Toolbox](https://www.docker.com/products/docker-toolbox) or [Docker Beta](https://beta.docker.com/))

## Serilog
- Clone this repo.
- Run `docker-compose build` to:
    + pull the images
    + build a docker image
- Run `docker-compose up` to:
    * pull the Serilog repo, 
    * build and test the lastest `dev` branch code from https://github.com/serilog/serilog.
- To enter the container with out using compose, use `docker run -it --entrypoint=/bin/bash serilog`

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

To run these, run `docker-compose -f samples.yml up --build`

This will 
* Build & run the sample docker images. 
* The console app periodically does a HTTP GET to the
    * `C#` Kestrel Sample
    * `F#` Kestrel Sample 
* The console app also logs to the [Literate](https://github.com/serilog/serilog-sinks-literate) and [Splunk](https://github.com/serilog/serilog-sinks-splunk) sinks. 
* The web apps are also configured to use Serilog via `Microsoft.Extensions.Logging` & `Serilog.Extensions.Logging`.   

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

# Windows Containers samples

## PreReqs

* Windows Server 2016 ([evaluate](https://www.microsoft.com/en-us/evalcenter/evaluate-windows-server-2016))
* Enable containers feature. See [MSDN documentation](https://msdn.microsoft.com/virtualization/windowscontainers/containers_welcome) for more details.
* Docker tools

### Quick setup
```powershell
# Add the containers feature and restart
Install-WindowsFeature containers
Restart-Computer -Force

# Download, install Docker Engine, Docker Compose
Invoke-WebRequest "https://download.docker.com/components/engine/windows-server/cs-1.12/docker.zip" -OutFile "$env:TEMP\docker.zip" -UseBasicParsing
Expand-Archive -Path "$env:TEMP\docker.zip" -DestinationPath $env:ProgramFiles

Invoke-WebRequest -Uri https://dl.bintray.com/docker-compose/master/docker-compose-Windows-x86_64.exe -OutFile $env:ProgramFiles\Docker\docker-compose.exe -UseBasicParsing

# set PATH
$env:Path += ";c:\program files\docker"
[Environment]::SetEnvironmentVariable("Path", $env:Path + ";C:\Program Files\Docker", [EnvironmentVariableTarget]::Machine)

# Configure Docker daemon to listen on both pipe and TCP
dockerd.exe -H npipe:////./pipe/docker_engine -H 0.0.0.0:2375 --register-service

# Start Docker daemon
Start-Service docker
```

## Run the Samples

This repo contains the following windows samples

* Seq Event Server, based on [Windows Server 2016 Server Core](https://hub.docker.com/r/microsoft/windowsservercore/) image
* Web App, based on [Windows Server 2016 Nano Server](https://hub.docker.com/r/microsoft/nanoserver/) image

To run these, run `docker-compose -f samples-windows.yml up`

Containers use `nat` network. To inspect what IPs they got run `docker network inspect nat` in the separate cmd shell and find your containers:
```cmd
"Containers": {
    "5f66928248090245cc4313d8ff114a27e2a98ffaaf25f77518e6b7b8eb042c3a": {
        "Name": "serilogdocker_web-sample_1",
        "EndpointID": "1b18aae7a2bb05e3b82e7bd35a63595a7aef828041e77c4da61c6ca36537ed5e",
        "IPv4Address": "172.23.144.124/16",
        "IPv6Address": ""
    },
    "83313f0f78ca0447801ef29d1953e65be3d73e1d168c627e5593a255eedd1672": {
        "Name": "serilogdocker_seq_1",
        "EndpointID": "6649b52db115b5f7288e4a99fa298b7fe4f1991892abdbed9305cb175143e775",
        "IPv4Address": "172.23.155.24/16",
        "IPv6Address": ""
    }
}
```

Navigate to the Web App and Seq Web UI (`http://172.23.144.124:5000` and `http://172.23.155.24:5341/` accordingly for the example above) 