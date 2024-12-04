using KiwiSaaS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KiwiSaaS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(KiwiSaaSEntityFrameworkCoreModule),
    typeof(KiwiSaaSApplicationContractsModule)
)]
public class KiwiSaaSDbMigratorModule : AbpModule
{
}
