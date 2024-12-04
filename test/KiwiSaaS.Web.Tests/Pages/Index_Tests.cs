using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace KiwiSaaS.Pages;

[Collection(KiwiSaaSTestConsts.CollectionDefinitionName)]
public class Index_Tests : KiwiSaaSWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
