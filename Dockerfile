# ----------------------------
# 1) Build-Stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projektdateien kopieren und Restoren
COPY ["TinyShop.Web/TinyShop.Web.csproj", "TinyShop.Web/"]
COPY ["TinyShop.Application/TinyShop.Application.csproj", "TinyShop.Application/"]
COPY ["TinyShop.Infrastructure/TinyShop.Infrastructure.csproj", "TinyShop.Infrastructure/"]
COPY ["TinyShop.Domain/TinyShop.Domain.csproj", "TinyShop.Domain/"]
RUN dotnet restore "TinyShop.Web/TinyShop.Web.csproj"

# Restlichen Code kopieren und publizieren
COPY . .
WORKDIR "/src/TinyShop.Web"
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
ENTRYPOINT ["dotnet", "TinyShop.Web.dll"]
