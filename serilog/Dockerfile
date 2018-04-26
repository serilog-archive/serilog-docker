FROM microsoft/dotnet:2.0-sdk

#Dependencies
ENV SERILOG_BRANCH dev 
ENV SERILOG_REPO https://github.com/serilog/serilog.git

# Get Git and Friends
RUN apt-get update \
	&& apt-get install -y wget curl git \
	&& apt-get -y autoremove \
	&& apt-get -y clean \
	&& rm -rf /var/lib/apt/lists/* 

COPY entry_point.sh entry_point.sh
RUN chmod +x /entry_point.sh

ENTRYPOINT ["/entry_point.sh"] 
