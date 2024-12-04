using Volo.Abp.Modularity;

namespace KiwiSaaS;

[DependsOn(
    typeof(KiwiSaaSApplicationModule),
    typeof(KiwiSaaSDomainTestModule)
)]
public class KiwiSaaSApplicationTestModule : AbpModule
{

}
