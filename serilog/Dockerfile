FROM microsoft/aspnet

#Dependencies
ENV DNX_BRANCH dev 

# Pull Serilog and build
RUN apt-get update \ 
	&& apt-get install -y wget curl git \
	&& git clone https://github.com/serilog/serilog.git \
	&& apt-get -y autoremove \
	&& apt-get -y clean \
	&& rm -rf /var/lib/apt/lists/*

WORKDIR /serilog
ADD build.sh /serilog/ 
RUN sh build.sh