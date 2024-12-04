using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace KiwiSaaS.Data;

/* This is used if database provider does't define
 * IKiwiSaaSDbSchemaMigrator implementation.
 */
public class NullKiwiSaaSDbSchemaMigrator : IKiwiSaaSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
