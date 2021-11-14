#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["USSDiscovery.API/USSDiscovery.API.csproj", "USSDiscovery.API/"]
COPY ["USSDiscovery.Application/USSDiscovery.Application.csproj", "USSDiscovery.Application/"]
COPY ["USSDiscovery.Infra.Data/USSDiscovery.Infra.Data.csproj", "USSDiscovery.Infra.Data/"]
COPY ["USSDiscovery.Domain/USSDiscovery.Domain.csproj", "USSDiscovery.Domain/"]
RUN dotnet restore "USSDiscovery.API/USSDiscovery.API.csproj"
COPY . .
WORKDIR "/src/USSDiscovery.API"
RUN dotnet build "USSDiscovery.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "USSDiscovery.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "USSDiscovery.API.dll"]