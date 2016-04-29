#!/bin/bash

rm serilog
git clone -b $SERILOG_BRANCH $SERILOG_REPO
cd serilog/src/Serilog

if [ "$1" = 'build' ]; then
    # Build Serilog 
    echo "build"  
    dotnet restore
    dotnet build -f dotnet5.1
elif [ "$1" = 'test' ]; then
    # Pull the source 
    echo "test" 
    dotnet restore
    dotnet build -f dotnet5.1
    echo "Nothing to test ATM!"
else
    echo "Sorry, I don't know what you would like to do!"
fi