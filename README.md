# Serilog with Docker
A docker image for testing Serilog on Docker platforms.  It also includes a number of sample apps.

## PreReqs

* Docker

# Building the Serilog Library
- Clone this repo.
- Run `docker-compose build` to:
    + pull the images
    + build a docker image
- Run `docker-compose up` to:
    * pull the Serilog repo, 
    * build and test the lastest `dev` branch code from https://github.com/serilog/serilog.
- To enter the container with out using compose, use `docker run -it --entrypoint=/bin/bash serilog`
 

# Run the Samples

This repo also contains the following samples:

* Console App
* Web App
* FSharp Web App

To run these, run `docker-compose -f samples.yml up --build`

This will

* Build & run the sample docker images.
* The console app periodically does a HTTP GET to the
    * `C#` Kestrel Sample
    * `F#` Kestrel Sample 
* The console app also logs to the [Console](https://github.com/serilog/serilog-sinks-console), [Seq](https://github.com/serilog/serilog-sinks-seq) and [Splunk](https://github.com/serilog/serilog-sinks-splunk) sinks.  
* The web apps are also configured to use Serilog via `Microsoft.Extensions.Logging` & `Serilog.Extensions.Logging`.

* Seq Host - http://localhost:80
* Splunk Host - http://localhost:8000


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