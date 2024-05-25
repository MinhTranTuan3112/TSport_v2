# FROM mcr.microsoft.com/mssql/server:2022-latest

# ENV SA_PASSWORD=YourStrong@Passw0rd
# ENV ACCEPT_EULA=Y

# COPY TSportDbScript.sql /docker-entrypoint-initdb.d/

# EXPOSE 1433
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /tsport_app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TSport.Api/TSport.Api.csproj", "TSport.Api/"] 
COPY ["TSport.Api.BusinessLogic/TSport.Api.BusinessLogic.csproj", "TSport.Api.BusinessLogic/"] 
COPY ["TSport.Api.DataAccess/TSport.Api.DataAccess.csproj", "TSport.Api.DataAccess/"] 
COPY ["TSport.Api.Shared/TSport.Api.Shared.csproj", "TSport.Api.Shared/"] 

RUN dotnet restore "TSport.Api/TSport.Api.csproj"
COPY . .

WORKDIR "/src/TSport.Api"
RUN dotnet build "TSport.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TSport.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /tsport_app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "TSport.Api.dll", "--environment=Development"]