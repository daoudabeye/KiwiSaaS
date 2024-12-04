using KiwiSaaS.Samples;
using Xunit;

namespace KiwiSaaS.EntityFrameworkCore.Applications;

[Collection(KiwiSaaSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<KiwiSaaSEntityFrameworkCoreTestModule>
{

}
