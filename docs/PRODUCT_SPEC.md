# Spécification Produit Agile — Kiwi SaaS ERP

## Vision
Construire une plateforme ERP modulaire open-source basée sur ABP (.NET 8) et une UI moderne (React/LeptonX), offrant un noyau gratuit et des modules premium via un marketplace.

## Objectifs stratégiques
- Time-to-market rapide pour des solutions SaaS verticales
- Extensibilité par modules/plugins (gratuits et payants)
- Qualité industrielle (tests, sécurité, multi-tenant, i18n)
- Adoption communautaire (documentation, gouvernance, RFC)

## Personas
- Admin Tenant: gère société, utilisateurs, droits, paramètres
- Responsable Ventes: devis, commandes, facturation
- Responsable Achats: fournisseurs, commandes achat
- Gestionnaire Stock: entrepôts, mouvements, inventaires
- Comptable: plan comptable, écritures, rapprochements
- Dev/Intégrateur: étend par modules, connecteurs, thèmes

## Hypothèses et Contraintes
- Multi-tenant natif ABP/OpenIddict
- EF Core (PostgreSQL recommandé), options SQL Server/MongoDB
- Architecture en couches (Domain, Application, HttpApi, Web)
- ABP Modularité (modules et dépendances explicites)

## Exigences Non-Fonctionnelles
- Sécurité: OAuth2/OIDC, RBAC, validation, audit logs
- Performance: P95 < 300ms pour requêtes app; pagination par défaut
- Observabilité: logs structurés, traces, métriques (Prometheus/OpenTelemetry)
- QA: >80% coverage sur services critiques; CI verte; scans dépendances
- DX: CLI scripts, docs, templates d’issues/PR, RFCs

## Architecture (haut niveau)
- Projets existants:
  - `src/KiwiSaaS.Domain/`, `src/KiwiSaaS.Domain.Shared/`
  - `src/KiwiSaaS.Application/`, `src/KiwiSaaS.Application.Contracts/`
  - `src/KiwiSaaS.HttpApi/`, `src/KiwiSaaS.Web/`
  - `src/KiwiSaaS.EntityFrameworkCore/`, `src/KiwiSaaS.DbMigrator/`
- AuthN/AuthZ: OpenIddict (certificats), Permissions ABP
- Données: EF Core + Migrations; Seed via `KiwiSaaS.DbMigrator`
- UI: Razor Pages/LeptonX; React pour modules avancés

## Modules ERP (cœur et extensions)
- Core (gratuit): Organisations, Utilisateurs/Rôles, Paramètres, Taxes, Produits, Contacts
- Sales (MVP): Devis, Commandes, Factures, Paiements (intégration passerelles en premium)
- Purchase (MVP): Demandes, Commandes, Réception
- Inventory (MVP): Entrepôts, Mouvements, Stocks, Inventaires
- Accounting (MVP): Plan comptable, Journaux, Écritures, TVA
- CRM (MVP): Leads, Opportunités, Pipeline, Activités
- eCommerce (ext.): Catalogue, Panier, Commandes, Checkout
- Subscriptions (ext.): Plans, Facturation récurrente, Prorata
- Reporting (ext.): Rapports, exports, dashboards

## Backlog (Epics -> Features -> User Stories)

### Epic: Noyau Plateforme
- Feature: Multi-tenant & Auth
  - Story: En tant qu'Admin, je peux créer des tenants et assigner des admins par tenant.
    - Acceptation: CRUD tenants; login admin tenant; séparation data par tenant.
- Feature: RBAC Permissions
  - Story: En tant qu'Admin, je peux créer des rôles et permissions modulaires.
    - Acceptation: CRUD rôles; assignation permissions par module.
- Feature: Paramètres & Localisation
  - Story: En tant qu'Admin, je configure devise, TVA, locales.
    - Acceptation: Stockage param; application UI/API; i18n.

### Epic: Catalogue de base
- Feature: Produits
  - Story: En tant que Responsable Ventes, je gère des produits (SKU, prix, TVA).
    - Acceptation: CRUD, recherche, taxes, unités.
- Feature: Contacts (Clients/Fournisseurs)
  - Story: En tant que Ventes/Achats, je gère contacts et adresses.
    - Acceptation: CRUD, catégorisation, dédoublonnage basique.

### Epic: Ventes (MVP)
- Feature: Devis -> Commande -> Facture
  - Story: Je crée un devis avec taxes et remises, et je le confirme en commande.
    - Acceptation: états (Draft, Sent, Confirmed); PDF; conversion.
  - Story: Je génère la facture depuis la commande.
    - Acceptation: numérotation; taxes; statut (Open, Paid).

### Epic: Achats (MVP)
- Feature: Commande d'achat
  - Story: Je crée une commande fournisseur et enregistre la réception.
    - Acceptation: états; lien stock; coût.

### Epic: Stock (MVP)
- Feature: Gestion des mouvements
  - Story: Je transfère du stock entre entrepôts.
    - Acceptation: réservations; ajustements; inventaire.

### Epic: Comptabilité (MVP)
- Feature: Journaux et écritures
  - Story: Génération d'écritures depuis les factures.
    - Acceptation: équilibre débit/crédit; export.

### Epic: CRM (MVP)
- Feature: Pipeline
  - Story: Je suis des opportunités par étapes.
    - Acceptation: Kanban; probabilité; forecast simple.

## Critères de Definition of Done (DoD)
- Tests passent et coverage > 70% sur la feature
- Documentation utilisateur et technique mise à jour
- Migration DB validée (montée/descente)
- Revue de code (2 reviewers si change majeur)
- Sécurité: entrées validées, permissions vérifiées

## KPIs
- Lead time PR médian < 3 jours
- Taux de réussite CI > 95%
- 1 release mineure toutes les 6–8 semaines
- 80% des issues triées sous 72h

## Plan de Sprints (6 sprints x 2 semaines)

### Sprint 1 — Noyau & Setup
Objectifs:
- CI/CD de base, templates GitHub, CONTRIBUTING
- Multi-tenant, Auth, Permissions (squelettes)
- Entités de base (Produits, Contacts)
Livrables:
- Workflows CI verts
- API CRUD basique Produits/Contacts
- Doc ARCHI + SPEC

### Sprint 2 — Ventes (Devis)
- Devis CRUD, taxes, remises
- PDF Devis, état Draft/Sent
- Tests d’intégration API

### Sprint 3 — Ventes (Commandes/Factures)
- Conversion Devis -> Commande -> Facture
- Numérotation; paiements mock

### Sprint 4 — Achats & Stock
- Commande d’achat; réception
- Mouvements de stock; inventaire de base

### Sprint 5 — Comptabilité (liaison)
- Écritures auto depuis factures
- Export comptable (CSV)

### Sprint 6 — CRM MVP & Dureté
- Pipeline Kanban; opportunités
- Observabilité, métriques, durcissement sécurité

## Risques & Mitigations
- Complexité comptable: limiter MVP; itérer avec RFC
- Performance multi-tenant: tests de charge; indexes
- Sécurité OIDC: certificats prod; revues sécurité

## Annexes
- Processus RFC (`docs/RFCS/0000-template.md`)
- ADR (`docs/architecture/adr/`)
