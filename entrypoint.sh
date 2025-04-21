#!/usr/bin/env bash
set -e

echo "🚀 Starting TinyShop in $ASPNETCORE_ENVIRONMENT mode on port $PORT..."
if [ "$ASPNETCORE_ENVIRONMENT" = "Development" ]; then
  exec dotnet watch run --urls="http://0.0.0.0:$PORT"
else
  exec dotnet TinyShop.Web.dll --urls="http://0.0.0.0:$PORT"
fi
