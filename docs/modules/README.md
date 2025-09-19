# Modules ERP — Plan & Frontières

## Gratuits (core)
- Organisations & Multi-tenant
- Utilisateurs/Rôles/Permissions
- Paramètres, Taxes, Produits, Contacts

## MVPs
- Sales: Devis, Commandes, Factures
- Purchase: Commandes Fournisseurs
- Inventory: Entrepôts, Mouvements, Inventaires
- Accounting: Journaux, Écritures, TVA
- CRM: Leads, Opportunités

## Extensions (premium)
- eCommerce, Subscriptions, Payments, Advanced Reporting

## Frontières & Contrats
- Chaque module expose des `Application.Contracts` (DTOs, Permissions)
- Entités Domain spécifiques au module
- HttpApi pour endpoints REST; événements d'intégration en option

## Données
- Migrations par module (si séparées) ou consolidées
- Transactions via UoW ABP
