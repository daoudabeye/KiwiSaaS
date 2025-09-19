# ADR 0001 — Tech Stack & Architecture

## Contexte
Besoin d'une base robuste et modulaire pour un ERP open-source.

## Décision
- Utiliser ABP sur .NET 8 pour modularité et DDD
- OpenIddict pour OIDC et multi-tenant
- EF Core + PostgreSQL par défaut
- UI Razor/LeptonX; React pour extensions riches

## Conséquences
- Productivité élevée grâce aux patterns ABP
- Courbe d'apprentissage ABP pour contributeurs
- Cross-platform via .NET

## Alternatives
- NestJS/Node + Prisma
- Java Spring Boot + Keycloak
Rejetées pour maximiser la cohérence avec code existant.
