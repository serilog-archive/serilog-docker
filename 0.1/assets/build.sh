# Just build core and console for now
dnu restore src/Serilog
dnu build src/Serilog --configuration Release --out /serilog/bin/
dnu pack src/Serilog --configuration Release --out /serilog/packages/

dnu restore src/Serilog.Sinks.Console/
dnu build src/Serilog.Sinks.Console/ --configuration Release --out /artefacts/Serilog.Sinks.Console/bin/
dnu pack src/Serilog.Sinks.Console/ --configuration Release --out /artefacts/Serilog.Sinks.Console/packages/

dnu restore src/Serilog.Enrichers.Thread/
dnu build src/Serilog.Enrichers.Thread/ --configuration Release --out /artefacts/Serilog.Enrichers.Thread/bin/
dnu pack src/Serilog.Enrichers.Thread/ --configuration Release --out /artefacts/Serilog.Enrichers.Thread/packages/
