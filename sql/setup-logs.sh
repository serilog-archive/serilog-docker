#wait for the SQL Server to come up
sleep 15s
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "test1234****" -d master -i CREATE.sql
# Hack to keep script running
while :; do echo 'SLEEP'; sleep 20000; done