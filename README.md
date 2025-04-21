# TinyShop Launch Plan

TinyShop is a lightweight e-commerce application showcasing a clean architecture .NET 8 and PostgreSQL stack. It provides a catalog of categories (e.g., Electronics, Coffee, Tools) and sample products, with automated database migrations and seed data. The live production instance is available at **https://tinyshop.simonfischer.dev/**.

---

## 🚀 Project Structure

```text
├── Dockerfile
├── entrypoint.sh
├── docker-compose.dev.yml
├── docker-compose.prod.yml
├── .env.example
├── TinyShop.Web/
│   └── Program.cs
├── TinyShop.Application/
├── TinyShop.Infrastructure/
│   └── Persistence (AppDbContext, Migrations, Repositories)
├── TinyShop.Domain/
└── README.md
``` 

- **Dockerfile**: Multi-stage build for SDK and runtime images.
- **entrypoint.sh**: Applies EF Core migrations and starts the application (watch/run or dll).
- **docker-compose.dev.yml**: Local development compose with Hot Reload and automatic migrations.
- **docker-compose.prod.yml**: Production compose with runtime image and Traefik labels.
- **.env.example**: Template for required environment variables.
- **Program.cs**: Configured for automatic `Database.Migrate()` before seeding.

---

## 🔧 Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Docker](https://docs.docker.com/get-docker/)
- [Docker Compose](https://docs.docker.com/compose/)
- **Traefik** configured on your production server (external Docker network: `traefik`)

---

## ⚙ Environment Variables

Rename `.env.example` to `.env` and fill in your values. Do **not** commit real secrets.

```bash
cp .env.example .env
# then edit .env to set your database credentials and port
```

Your ` .env.example` should define placeholders only, for example:

```dotenv
# Port for Kestrel and Traefik
PORT=<your_port>

# PostgreSQL host and port
POSTGRES_HOST=<your_postgres_host>
POSTGRES_PORT=<your_postgres_port>

# Development database credentials
DEV_POSTGRES_DB=<your_dev_db_name>
DEV_POSTGRES_USER=<your_dev_db_user>
DEV_POSTGRES_PASSWORD=<your_dev_db_password>

# Production database credentials
PROD_POSTGRES_DB=<your_prod_db_name>
PROD_POSTGRES_USER=<your_prod_db_user>
PROD_POSTGRES_PASSWORD=<your_prod_db_password>
```

---

## 🏗️ Build & Launch

### Local Development

1. **Start Dev Stack**:
   ```bash
   docker compose -f docker-compose.dev.yml up --build
   ```
2. **Access Application**: http://localhost:${PORT} (default: 85)
3. **Database**: migrations and seed data apply automatically via `entrypoint.sh`.

---

### Production Deployment

1. **Ensure Traefik** is running on Docker network `traefik` and configured for `tinyshop.simonfischer.dev`.
2. **Start Prod Stack**:
   ```bash
   docker compose -f docker-compose.prod.yml up --build -d
   ```
3. **Visit**: https://tinyshop.simonfischer.dev

---

## 🧩 How It Works

- **Automatic Migrations**: `ctx.Database.Migrate()` runs on startup.
- **Data Seeding**: `DataSeeder.SeedAsync()` populates categories and products if empty.
- **entrypoint.sh**: Runs migrations then starts app in Dev or Prod mode.
- **Networking**:
    - Dev: maps host port `${PORT}` to container.
    - Prod: exposes `${PORT}` and uses Traefik labels for routing.

---

## 🙌 Tips

- **Rebuild Web Image**:
  ```bash
  docker compose -f docker-compose.dev.yml build tinyshop
  ```
- **View Logs**:
  ```bash
  docker compose -f docker-compose.prod.yml logs -f tinyshop
  ```
- **Shell in Container**:
  ```bash
  docker compose -f docker-compose.dev.yml exec tinyshop-dev bash
  ```

Happy shopping with TinyShop! 🚀

