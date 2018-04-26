FROM microsoft/dotnet:2.0-sdk AS build
# FROM microsoft/aspnetcore:2.0.0 AS build
WORKDIR /sample
ADD src /sample
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.0-runtime AS runtime
ENV ASPNETCORE_URLS http://*:5000
WORKDIR /sample
COPY --from=build /sample/out ./
ENTRYPOINT ["dotnet", "web-sample.dll"]