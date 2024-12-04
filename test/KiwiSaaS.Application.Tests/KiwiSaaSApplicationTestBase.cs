using Volo.Abp.Modularity;

namespace KiwiSaaS;

public abstract class KiwiSaaSApplicationTestBase<TStartupModule> : KiwiSaaSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
