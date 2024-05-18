FROM mcr.microsoft.com/mssql/server:2022-latest

ENV SA_PASSWORD=YourStrong@Passw0rd
ENV ACCEPT_EULA=Y

COPY TSportDbScript.sql /docker-entrypoint-initdb.d/

EXPOSE 1433