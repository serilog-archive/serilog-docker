# serilog-docker
A docker image for testing Serilog on *nix platforms

- Clone the repo
- Run `make`

```
Step 1 : FROM microsoft/aspnet
 ---> xxxxxxxxxx

....
.... 

Step 9 : RUN sh assets/build.sh
 ---> Running in 8bd1502932ab
Microsoft .NET Development Utility Mono-x64-1.0.0-rc1-16231

  GET https://api.nuget.org/v3/index.json
  OK https://api.nuget.org/v3/index.json 1213ms

....
.... 

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time elapsed 00:00:01.4512615
Total build time elapsed: 00:00:01.4658105
Total projects built: 1
 ---> 0e96769848ff
Removing intermediate container xxxxxxxxx
Successfully built xxxxxxxxxx
```

- Run `docker run -t -i Serilog:0.1`