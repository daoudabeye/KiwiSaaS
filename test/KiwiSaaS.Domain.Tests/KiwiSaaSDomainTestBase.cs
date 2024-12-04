using Volo.Abp.Modularity;

namespace KiwiSaaS;

/* Inherit from this class for your domain layer tests. */
public abstract class KiwiSaaSDomainTestBase<TStartupModule> : KiwiSaaSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
