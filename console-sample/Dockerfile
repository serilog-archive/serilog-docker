FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /sample
ADD src /sample
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.0-runtime AS runtime
WORKDIR /sample
COPY --from=build /sample/out ./
ENTRYPOINT ["dotnet", "console-sample.dll"]