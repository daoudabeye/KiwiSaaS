# Architecture Overview

## Stack
- .NET 8, ABP Framework, OpenIddict
- EF Core (PostgreSQL recommandé)
- UI: ASP.NET Core MVC/Razor (LeptonX), modules React possibles

## Couches
- `Domain` / `Domain.Shared`: entités, agrégats, événements, invariants
- `Application` / `Application.Contracts`: services applicatifs, DTOs, permissions
- `HttpApi` / `Web`: endpoints, UI, auth
- `EntityFrameworkCore`: mappage, migrations, UoW
- `DbMigrator`: migrations + seed

## Modularité
- Dépendances explicites entre modules ABP
- Conventions de nommage `KiwiSaaS.<Module>`
- Plugins premium optionnels, isolés

## Sécurité
- OpenIddict (certificats signature/chiffrement)
- RBAC basé sur permissions ABP
- Validation côté serveur et côté client

## Observabilité
- Logs structurés, traçage, métriques (OpenTelemetry)

## Données & Multi-tenant
- Isolation par tenant; filtres dans repositories/services
- Stratégie de migration: `DbMigrator`
