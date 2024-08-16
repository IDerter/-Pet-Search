#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Pet-Search.API/Pet-Search.API.csproj", "src/Pet-Search.API/"]
COPY ["src/Pet-Search.Application/Pet-Search.Application.csproj", "src/Pet-Search.Application/"]
COPY ["src/Pet-Search.Domain/Pet-Search.Domain.csproj", "src/Pet-Search.Domain/"]
COPY ["src/Pet-Search.Infrastructure/Pet-Search.Infrastructure.csproj", "src/Pet-Search.Infrastructure/"]
RUN dotnet restore "./src/Pet-Search.API/./Pet-Search.API.csproj"
COPY . .
WORKDIR "/src/src/Pet-Search.API"
RUN dotnet build "./Pet-Search.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Pet-Search.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pet-Search.API.dll"]