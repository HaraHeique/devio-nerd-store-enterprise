# O contexto no arquivo docker compose é o diretório /src

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./web/NSE.WebApp.MVC/NSE.WebApp.MVC.csproj", "web/NSE.WebApp.MVC/"]
RUN dotnet restore "web/NSE.WebApp.MVC/NSE.WebApp.MVC.csproj"
COPY . .
WORKDIR "web/NSE.WebApp.MVC"
RUN dotnet build "NSE.WebApp.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.WebApp.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.WebApp.MVC.dll"]