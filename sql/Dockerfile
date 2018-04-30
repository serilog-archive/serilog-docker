FROM microsoft/mssql-server-linux:2017-latest

# Create app directory
RUN mkdir -p /usr/src/
WORKDIR /usr/src/
COPY . /usr/src/
RUN chmod +x /usr/src/setup-logs.sh
CMD /bin/bash ./entrypoint.sh