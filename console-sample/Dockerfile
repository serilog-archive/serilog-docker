# FROM microsoft/aspnet
FROM microsoft/dotnet

COPY entry_point.sh entry_point.sh
RUN chmod +x /entry_point.sh

ADD src/console /console-sample
ENTRYPOINT ["/entry_point.sh"]