#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/web/NSE.WebApp.MVC6/NSE.WebApp.MVC6.csproj", "src/web/NSE.WebApp.MVC6/"]
RUN dotnet restore "src/web/NSE.WebApp.MVC6/NSE.WebApp.MVC6.csproj"
COPY . .
WORKDIR "/src/src/web/NSE.WebApp.MVC6"
RUN dotnet build "NSE.WebApp.MVC6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.WebApp.MVC6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.WebApp.MVC6.dll"]