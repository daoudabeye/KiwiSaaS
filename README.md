
# Kiwi SaaS Framework

Kiwi est une plateforme modulaire open-source basée sur le framework ABP et React. Elle est conçue pour permettre aux développeurs et entreprises de créer rapidement des solutions SaaS robustes et extensibles. Avec Kiwi, vous pouvez modéliser vos entités, gérer les relations entre elles, et intégrer des fonctionnalités avancées grâce à son architecture modulaire.

---

## 🛠️ Fonctionnalités principales

- **Framework ABP et React** : Puissance d'ASP.NET Core combinée à une interface utilisateur moderne.
- **Architecture modulaire** : Ajouter ou retirer facilement des modules selon vos besoins.
- **Entités dynamiques** : Modélisation intuitive des entités et relations avec une interface visuelle.
- **Gestion des plugins** : Installer, activer, ou désactiver des plugins pour étendre les fonctionnalités.
- **Data Virtualization** : Accès optimisé et abstrait aux données métier.

---

## 🚀 Commencer avec Kiwi

### Prérequis

- **.NET 8 ou plus récent**
- **Node.js** et **npm**
- Base de données compatible (PostgreSQL, SQL Server, MongoDB)

### Installation

1. Clonez le projet :
   ```bash
   git clone https://github.com/<votre-organisation>/kiwi.git
   cd kiwi
   ```

2. Configurez la base de données :
   Modifiez le fichier `appsettings.json` pour configurer la chaîne de connexion.


### Configurations

La solution est livrée avec une configuration par défaut qui fonctionne immédiatement. Cependant, vous pouvez envisager de modifier la configuration suivante avant d'exécuter votre solution:

* Vérifiez les `ConnectionStrings` dans les fichiers `appsettings.json` sous les projets `KiwiSaaS.Web` et `KiwiSaaS.DbMigrator` et modifiez-les si vous en avez besoin.

### Avant d'exécuter l'application

#### Générer un certificat de signature

Dans l'environnement de production, vous devez utiliser un certificat de signature de production. ABP Framework configure les certificats de signature et de chiffrement dans votre application et attend un `openiddict.pfx` déposer dans votre candidature.

Ce certificat est déjà généré par ABP CLI, vous n'avez donc la plupart du temps pas besoin de le générer vous-même. Cependant, si vous devez générer un certificat, vous pouvez utiliser la commande suivante:

```bash
dotnet dev-certs https -v -ep openiddict.pfx -p 83b6a16e-18e4-44fe-89c8-efe3f55537d2
```

> `83b6a16e-18e4-44fe-89c8-efe3f55537d2` is the password of the certificate, you can change it to any password you want.

It is recommended to use **two** RSA certificates, distinct from the certificate(s) used for HTTPS: one for encryption, one for signing.

For more information, please refer to: https://documentation.openiddict.com/configuration/encryption-and-signing-credentials.html#registering-a-certificate-recommended-for-production-ready-scenarios

> Also, see the [Configuring OpenIddict](https://abp.io/docs/latest/deployment/configuring-openiddict#production-environment) documentation for more information.

#### Install Client-Side Libraries

Run the following command in the directory of your final application:

```bash
abp install-libs
```

> This command installs all NPM packages for MVC/Razor Pages and Blazor Server UIs and this command is already run by the ABP CLI, so most of the time you don't need to run this command manually.

#### Create the Database

Run `KiwiSaaS.DbMigrator` to create the initial database. This should be done in the first run. It is also needed if a new database migration is added to the solution later.

### Solution structure

This is a layered monolith application that consists of the following applications:

* `KiwiSaaS.DbMigrator`: A console application which applies the migrations and also seeds the initial data. It is useful on development as well as on production environment.
* `KiwiSaaS.Web`: ASP.NET Core MVC / Razor Pages application that is the essential web application of the solution.

### Deploying the application

Deploying an ABP application is not different than deploying any .NET or ASP.NET Core application. However, there are some topics that you should care about when you are deploying your applications. You can check ABP's [Deployment documentation](https://abp.io/docs/latest/deployment) before deploying your application.

### Additional resources

You can see the following resources to learn more about your solution and the ABP Framework:

* [Web Application Development Tutorial](https://abp.io/docs/latest/tutorials/book-store/part-01?UI=Blazor&DB=EF)
* [Application Startup Template Structure](https://abp.io/docs/latest/solution-templates/layered-web-application)
* [LeptonX Lite MVC UI](https://abp.io/docs/latest/ui-themes/lepton-x-lite/asp-net-core)

### Démo en ligne

Explorez une version démo en ligne : [Demo Kiwi SaaS](https://demo.kiwi-saas.io).

---

## 🧩 Modules payants

Kiwi propose des fonctionnalités de base gratuitement, mais certains modules avancés (comme l'intégration de paiements ou des analyses avancées) sont disponibles sous forme de plugins payants. Consultez le [Kiwi Marketplace](https://marketplace.kiwi-saas.io) pour en savoir plus.

---

## 🛡️ Licence

Ce projet est sous licence **GNU Affero General Public License v3.0 (AGPL-3.0)**. Consultez le fichier [LICENSE](./LICENSE) pour plus de détails.

> Les modules payants ne sont pas couverts par cette licence. Pour les conditions spécifiques des modules premium, veuillez consulter leur documentation respective.

---

## 📖 Documentation

La documentation complète est disponible sur [https://docs.kiwi-saas.io](https://docs.kiwi-saas.io).

---

## 📬 Contributions

Nous accueillons avec plaisir les contributions de la communauté !

1. Forkez ce dépôt.
2. Créez une branche de fonctionnalité :
   ```bash
   git checkout -b ma-nouvelle-fonctionnalité
   ```
3. Soumettez une pull request.

---

## ✨ Crédits

- **Auteur** : Daouda Beye
- **Contact** : [contact@kiwi-saas.io](mailto:contact@kiwi-saas.io)

---

## 🌟 Rejoignez la communauté

- [Forum officiel](https://community.kiwi-saas.io)
- [Slack](https://slack.kiwi-saas.io)
- [Twitter](https://twitter.com/kiwi_saas)

---

Happy coding! 💻
