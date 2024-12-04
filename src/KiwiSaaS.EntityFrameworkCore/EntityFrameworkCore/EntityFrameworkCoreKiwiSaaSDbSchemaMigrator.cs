using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KiwiSaaS.Data;
using Volo.Abp.DependencyInjection;

namespace KiwiSaaS.EntityFrameworkCore;

public class EntityFrameworkCoreKiwiSaaSDbSchemaMigrator
    : IKiwiSaaSDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreKiwiSaaSDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the KiwiSaaSDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<KiwiSaaSDbContext>()
            .Database
            .MigrateAsync();
    }
}
