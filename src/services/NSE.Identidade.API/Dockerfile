FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./services/NSE.Identidade.API/NSE.Identidade.API.csproj", "services/NSE.Identidade.API/"]
COPY ["./building-blocks/NSE.Core/NSE.Core.csproj", "/building-blocks/NSE.Core/"]
COPY ["./building-blocks/NSE.WebAPI.Core/NSE.WebAPI.Core.csproj", "building-blocks/NSE.WebAPI.Core/"]
COPY ["./building-blocks/NSE.Infra.MessageBus/NSE.Infra.MessageBus.csproj", "./building-blocks/NSE.Infra.MessageBus/"]
RUN dotnet restore "./services/NSE.Identidade.API/NSE.Identidade.API.csproj"
COPY . .
WORKDIR "services/NSE.Identidade.API"
RUN dotnet build "NSE.Identidade.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Identidade.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Identidade.API.dll"]