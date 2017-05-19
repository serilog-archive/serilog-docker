FROM microsoft/dotnet:1.1.2-sdk

ADD src /sample
COPY entry_point.sh entry_point.sh
RUN chmod +x /entry_point.sh
EXPOSE 5001
ENTRYPOINT ["/entry_point.sh"]