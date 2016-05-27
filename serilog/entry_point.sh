#!/bin/bash
sudo https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0/scripts/obtain/dotnet-install.sh
rm serilog
git clone -b $SERILOG_BRANCH $SERILOG_REPO

cd serilog/
sh build.sh