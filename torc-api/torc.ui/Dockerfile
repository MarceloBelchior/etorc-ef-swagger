#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["torc.ui/torc.ui.csproj", "torc.ui/"]
COPY ["torc.Iface/torc.Iface.csproj", "torc.Iface/"]
COPY ["tork.model/torc.model.csproj", "tork.model/"]
COPY ["torc.business/torc.business.csproj", "torc.business/"]
COPY ["torc.database/torc.database.csproj", "torc.database/"]
RUN dotnet restore "torc.ui/torc.ui.csproj"
COPY . .
WORKDIR "/src/torc.ui"
RUN dotnet build "torc.ui.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "torc.ui.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "torc.ui.dll"]
