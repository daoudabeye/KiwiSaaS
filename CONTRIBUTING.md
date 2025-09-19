# Contribuer à Kiwi SaaS

Merci de votre intérêt pour Kiwi SaaS. Ce guide explique comment configurer votre environnement, proposer des changements et respecter les standards du projet.

## Prérequis
- .NET 8 SDK
- Node.js LTS et npm
- Docker (optionnel) pour les bases de données locales

## Mise en place locale
```bash
# cloner
git clone https://github.com/<org>/KiwiSaaS.git
cd KiwiSaaS

# restaurer et builder
dotnet restore KiwiSaaS.sln
dotnet build KiwiSaaS.sln -c Release

# initialiser la base
dotnet run --project src/KiwiSaaS.DbMigrator

# lancer l'app (exemple MVC/Razor)
dotnet run --project src/KiwiSaaS.Web
```

## Branches et fluxo Git
- main: stable, releases
- develop: intégration (prochaine release)
- feat/<slug>: nouvelle fonctionnalité
- fix/<slug>: correction
- chore/<slug>: maintenance

Adoptez les Conventional Commits:
```
feat(sales): add quotation workflow
fix(auth): handle token refresh failure
chore(ci): speed up test job
```

## Style de code
- C#: dotnet-format (profil .editorconfig)
- Nommage et analyzers: règles par défaut .NET + conventions ABP
- Front (si applicable): ESLint/Prettier (React)

## Tests
- Emplacement: `test/`
- Lancer: `dotnet test -c Release`
- Écrire des tests unitaires et d’intégration (EF Core InMemory/SQLite)

## Migration base de données
- Créer une migration: `dotnet ef migrations add <Name> -p src/KiwiSaaS.EntityFrameworkCore -s src/KiwiSaaS.DbMigrator`
- Appliquer: `dotnet run --project src/KiwiSaaS.DbMigrator`

## Pull Requests
- Liez une issue (`Fixes #123`)
- Mettez à jour la doc si nécessaire
- Ajoutez/Mettre à jour des tests
- Vérifiez la CI (build + tests)
- Remplissez la checklist du template PR

## Sécurité
Ne divulguez pas de vulnérabilités publiquement. Consultez `SECURITY.md`.

## Gouvernance
Décisions techniques via RFCs (`docs/RFCS`). Voir `GOVERNANCE.md`.
