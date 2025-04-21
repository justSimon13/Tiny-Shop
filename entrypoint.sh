#!/usr/bin/env bash
set -e

# Erst Migrations anwenden
echo "⏳ Applying EF migrations..."
dotnet ef database update --no-build --project ../TinyShop.Infrastructure --startup-project . 

# Dann die App starten
echo "🚀 Starting TinyShop..."
# Unterscheidung Dev/Prod via ENV
if [ "$ASPNETCORE_ENVIRONMENT" = "Development" ]; then
  exec dotnet watch run --urls="http://0.0.0.0:85"
else
  exec dotnet TinyShop.Web.dll --urls="http://0.0.0.0:85"
fi
