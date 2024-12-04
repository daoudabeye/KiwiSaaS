using Kiwi.Core.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Kiwi.Core;

public abstract class CoreController : AbpControllerBase
{
    protected CoreController()
    {
        LocalizationResource = typeof(CoreResource);
    }
}
