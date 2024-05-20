#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TSport.Api/TSport.Api.csproj", "TSport.Api/"]
COPY ["TSport.Api.BusinessLogic/TSport.Api.BusinessLogic.csproj", "TSport.Api.BusinessLogic/"]
COPY ["TSport.Api.DataAccess/TSport.Api.DataAccess.csproj", "TSport.Api.DataAccess/"]
COPY ["TSport.Api.Shared/TSport.Api.Shared.csproj", "TSport.Api.Shared/"]
RUN dotnet restore "./TSport.Api/TSport.Api.csproj"
COPY . .
WORKDIR "/src/TSport.Api"
RUN dotnet build "./TSport.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TSport.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TSport.Api.dll"]