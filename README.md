# serilog-docker
A docker image for testing Serilog on *nix platforms.  Also some sample apps.


## Getting started
- Clone the repo
- Run `docker-compose up`

```
Building serilog
Step 1 : FROM microsoft/dotnet
 ---> xxxxx
Step 2 : ENV SERILOG_BRANCH dev
 ---> Using cache
....
....  
Successfully built xxxxxxxxxx
```

- Run `docker run -it serilog build`


docker-compose -f samples.yml up

 