# Consultez https://aka.ms/customizecontainer pour savoir comment personnaliser votre conteneur de débogage et comment Visual Studio utilise ce Dockerfile pour générer vos images afin d’accélérer le débogage.

# Cet index est utilisé lors de l’exécution à partir de VS en mode rapide (par défaut pour la configuration de débogage)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Cette phase est utilisée pour générer le projet de service
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/KiwiSaaS.Web/KiwiSaaS.Web.csproj", "src/KiwiSaaS.Web/"]
COPY ["src/KiwiSaaS.Application/KiwiSaaS.Application.csproj", "src/KiwiSaaS.Application/"]
COPY ["src/KiwiSaaS.Domain/KiwiSaaS.Domain.csproj", "src/KiwiSaaS.Domain/"]
COPY ["src/KiwiSaaS.Domain.Shared/KiwiSaaS.Domain.Shared.csproj", "src/KiwiSaaS.Domain.Shared/"]
COPY ["src/KiwiSaaS.Application.Contracts/KiwiSaaS.Application.Contracts.csproj", "src/KiwiSaaS.Application.Contracts/"]
COPY ["src/KiwiSaaS.HttpApi/KiwiSaaS.HttpApi.csproj", "src/KiwiSaaS.HttpApi/"]
COPY ["src/KiwiSaaS.EntityFrameworkCore/KiwiSaaS.EntityFrameworkCore.csproj", "src/KiwiSaaS.EntityFrameworkCore/"]
RUN dotnet restore "./src/KiwiSaaS.Web/KiwiSaaS.Web.csproj"
COPY . .
WORKDIR "/src/src/KiwiSaaS.Web"
RUN dotnet build "./KiwiSaaS.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Cette étape permet de publier le projet de service à copier dans la phase finale
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KiwiSaaS.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Cette phase est utilisée en production ou lors de l’exécution à partir de VS en mode normal (par défaut quand la configuration de débogage n’est pas utilisée)
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "KiwiSaaS.Web.dll"]

FROM base AS final
WORKDIR /app
COPY --from=build /src .
ENTRYPOINT ["dotnet", "src/KiwiSaaS.Web.dll"]