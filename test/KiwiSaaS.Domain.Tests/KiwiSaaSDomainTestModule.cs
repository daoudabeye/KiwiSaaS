using Volo.Abp.Modularity;

namespace KiwiSaaS;

[DependsOn(
    typeof(KiwiSaaSDomainModule),
    typeof(KiwiSaaSTestBaseModule)
)]
public class KiwiSaaSDomainTestModule : AbpModule
{

}
