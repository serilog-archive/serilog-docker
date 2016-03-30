FROM microsoft/aspnet
  
ADD src/console /console-sample
RUN dnu restore console-sample /
    && dnu build console-sample
    # && dnu build console-sample --out /console-sample/bin/
    # && dnu build console-sample --configuration Release --out /console-sample/bin/
    # && dnu pack console-sample --configuration Release --out /console-sample/packages/