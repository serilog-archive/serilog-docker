FROM microsoft/aspnet

#Dependencies
RUN apt-get update
RUN apt-get install -y wget curl git
ENV DNX_BRANCH dev 

# Serilog
RUN git clone https://github.com/serilog/serilog.git
WORKDIR /serilog
ADD assets /serilog/assets 
ADD testapp /serilog/testapp
RUN sh assets/build.sh