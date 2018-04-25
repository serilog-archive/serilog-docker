#!/bin/bash
rm -r -f serilog/ 
set -e
git clone -b $SERILOG_BRANCH $SERILOG_REPO --depth=1 
cd serilog/

ulimit -n 2048

sh build.sh