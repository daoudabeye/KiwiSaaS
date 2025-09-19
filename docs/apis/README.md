# APIs — Vue d'ensemble

Les endpoints HTTP sont exposés par `src/KiwiSaaS.HttpApi/` et documentés via Swagger (une fois activé). Chaque module expose ses contrats via `Application.Contracts` et les implémente dans `Application`.

- Auth & Tenants: endpoints d'authentification et gestion des tenants (OpenIddict/ABP)
- Core: Produits, Contacts, Taxes, Paramètres
- Sales: Devis, Commandes, Factures
- Purchase: Commandes Fournisseurs
- Inventory: Entrepôts, Mouvements
- Accounting: Journaux, Écritures
- CRM: Leads, Opportunités

Guide d'extension:
- Ajouter DTOs & Permissions dans `<Module>.Application.Contracts`
- Implémenter AppServices dans `<Module>.Application`
- Exposer via controllers dans `HttpApi`
