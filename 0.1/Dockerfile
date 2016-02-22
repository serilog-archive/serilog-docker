FROM microsoft/aspnet

#Dependencies
RUN apt-get update
RUN apt-get install -y wget curl git
ENV DNX_BRANCH dev 

# Serilog
RUN git clone https://github.com/serilog/serilog.git
WORKDIR /serilog

RUN sh build.sh