#!/bin/bash
rm -r -f serilog/ 
set -e
git clone -b $SERILOG_BRANCH $SERILOG_REPO --depth=1 
cd serilog/

ulimit -n 2048

dotnet --info
dotnet restore

for path in src/**/*.csproj; do
    dotnet build -f netstandard1.0 -c Release ${path}
    dotnet build -f netstandard1.3 -c Release ${path}
done

for path in test/*.Tests/*.csproj; do
    dotnet test -f netcoreapp1.0  -c Release ${path}
done