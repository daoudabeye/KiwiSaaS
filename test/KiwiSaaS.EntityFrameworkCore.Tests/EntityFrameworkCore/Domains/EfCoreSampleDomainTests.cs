using KiwiSaaS.Samples;
using Xunit;

namespace KiwiSaaS.EntityFrameworkCore.Domains;

[Collection(KiwiSaaSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<KiwiSaaSEntityFrameworkCoreTestModule>
{

}
