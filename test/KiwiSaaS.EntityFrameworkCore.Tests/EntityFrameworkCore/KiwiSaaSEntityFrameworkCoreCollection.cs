using Xunit;

namespace KiwiSaaS.EntityFrameworkCore;

[CollectionDefinition(KiwiSaaSTestConsts.CollectionDefinitionName)]
public class KiwiSaaSEntityFrameworkCoreCollection : ICollectionFixture<KiwiSaaSEntityFrameworkCoreFixture>
{

}
