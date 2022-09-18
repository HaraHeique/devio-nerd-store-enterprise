# OBS.: Olhe se o arquivo está LF

# aguardando 30 segundos para aguardar o provisionamento e start do banco
sleep 90s

# rodar o comando para criar o banco
#/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "MeuDB@123" -i criacao-banco-docker.sql
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "MeuDB@123" -i BackupDbScript.sql