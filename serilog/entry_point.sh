#!/bin/bash
 
git clone -b $SERILOG_BRANCH $SERILOG_REPO

cd serilog/
dotnet restore

cd src/Serilog/

dotnet build -f netstandard1.0 -c Release
dotnet build -f netstandard1.3 -c Release

cd ../..
cd test/Serilog.Tests/ 

dotnet build -f netcoreapp1.0
dotnet test -f netcoreapp1.0  -c Release