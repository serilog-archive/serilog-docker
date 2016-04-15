FROM microsoft/aspnet

#Dependencies
ENV DNX_BRANCH dev 

# Pull Serilog and build
RUN apt-get update \ 
	&& apt-get install -y wget curl git \
	&& apt-get -y autoremove \
	&& apt-get -y clean \
	&& rm -rf /var/lib/apt/lists/*

RUN mkdir /src
WORKDIR /src
ADD build.sh /src/ 
RUN sh build.sh