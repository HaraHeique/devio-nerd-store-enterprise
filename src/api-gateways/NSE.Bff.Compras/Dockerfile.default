#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/api-gateways/NSE.Bff.Compras/NSE.Bff.Compras.csproj", "src/api-gateways/NSE.Bff.Compras/"]
RUN dotnet restore "src/api-gateways/NSE.Bff.Compras/NSE.Bff.Compras.csproj"
COPY . .
WORKDIR "/src/src/api-gateways/NSE.Bff.Compras"
RUN dotnet build "NSE.Bff.Compras.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Bff.Compras.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Bff.Compras.dll"]