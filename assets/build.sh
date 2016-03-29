# Just build core and console for now
dnu restore src/Serilog
dnu build src/Serilog --configuration Release --out /serilog/bin/
dnu pack src/Serilog --configuration Release --out /serilog/packages/