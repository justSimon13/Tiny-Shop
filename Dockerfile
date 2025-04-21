# ----------------------------
# 1) Build-Stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["TinyShop.Web/TinyShop.Web.csproj", "TinyShop.Web/"]
COPY ["TinyShop.Application/TinyShop.Application.csproj", "TinyShop.Application/"]
COPY ["TinyShop.Infrastructure/TinyShop.Infrastructure.csproj", "TinyShop.Infrastructure/"]
COPY ["TinyShop.Domain/TinyShop.Domain.csproj", "TinyShop.Domain/"]
RUN dotnet restore "TinyShop.Web/TinyShop.Web.csproj"

COPY . .
WORKDIR "/src/TinyShop.Web"
RUN dotnet publish "TinyShop.Web.csproj" -c Release -o /app/publish

# ----------------------------
# 2) Runtime-Stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

EXPOSE 85
ENTRYPOINT ["./entrypoint.sh"]
