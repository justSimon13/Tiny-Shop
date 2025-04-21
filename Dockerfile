# ----------------------------
# 1) Build-Stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projektdateien kopieren und Restoren
COPY ["TinyStore.Web/TinyStore.Web.csproj", "TinyStore.Web/"]
COPY ["TinyStore.Application/TinyStore.Application.csproj", "TinyStore.Application/"]
COPY ["TinyStore.Infrastructure/TinyStore.Infrastructure.csproj", "TinyStore.Infrastructure/"]
COPY ["TinyStore.Domain/TinyStore.Domain.csproj", "TinyStore.Domain/"]
RUN dotnet restore "TinyStore.Web/TinyStore.Web.csproj"

# Restlichen Code kopieren und publizieren
COPY . .
WORKDIR "/src/TinyStore.Web"
RUN dotnet publish -c Release -o /app/publish

# ----------------------------
# 2) Runtime-Stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# App-Verzeichnis kopieren
COPY --from=build /app/publish .

# Port, auf dem die Web lauscht
EXPOSE 80

# Startbefehl
ENTRYPOINT ["dotnet", "TinyStore.Web.dll"]
