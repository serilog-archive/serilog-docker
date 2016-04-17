#!/bin/bash

git clone -b $SERILOG_BRANCH $SERILOG_REPO
cd serilog
 
if [ "$1" = 'build' ]; then
    # Build Serilog 
    echo "build"  
    cd 
    dotnet restore serilog/src/serilog
    dotnet build serilog/src/serilog
elif [ "$1" = 'test' ]; then
    # Pull the source 
    echo "test" 
    dotnet restore
    dotnet build
    echo "Nothing to test ATM!"
else
    echo "Sorry, I don't know what you would like to do!"
fi