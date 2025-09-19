# Guide de développement

## Prérequis
- .NET 8 SDK
- Node.js LTS et npm
- PostgreSQL (recommandé) ou SQL Server
- ABP CLI (optionnel): `dotnet tool install -g Volo.Abp.Cli`

## Mise en place
```bash
# Restaurer et builder
dotnet restore KiwiSaaS.sln
dotnet build KiwiSaaS.sln -c Debug

# Créer/mettre à jour la base
# Configurez la chaîne de connexion dans appsettings.json si besoin
 dotnet run --project src/KiwiSaaS.DbMigrator

# Lancer l'application web
 dotnet run --project src/KiwiSaaS.Web
```

## Tests
```bash
dotnet test KiwiSaaS.sln -c Debug --logger trx
```

## Migrations EF Core
```bash
# Ajouter une migration
 dotnet ef migrations add <Name> -p src/KiwiSaaS.EntityFrameworkCore -s src/KiwiSaaS.DbMigrator

# Appliquer
 dotnet run --project src/KiwiSaaS.DbMigrator
```

## Conventions
- Commits: Conventional Commits
- C#: suivez `.editorconfig` et utilisez `dotnet format`
- PR: lier une issue, MAJ doc, tests, CI verte

## Débogage
- Utilisez `KiwiSaaS.DbMigrator` pour reseeder si besoin
- Logs: Serilog/ASP.NET Core par défaut, configurez niveaux dans `appsettings.*.json`

## Structure
- `src/`: couches Domain, Application, HttpApi, Web, EFCore, DbMigrator
- `test/`: tests unitaires et d'intégration
- `modules/`: modules externes/optionnels

## Observabilité (planifié)
- OpenTelemetry pour traces et métriques
- Dashboards (Grafana/Prometheus)
