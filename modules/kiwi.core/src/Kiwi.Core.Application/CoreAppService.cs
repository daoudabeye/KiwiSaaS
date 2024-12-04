using Kiwi.Core.Localization;
using Volo.Abp.Application.Services;

namespace Kiwi.Core;

public abstract class CoreAppService : ApplicationService
{
    protected CoreAppService()
    {
        LocalizationResource = typeof(CoreResource);
        ObjectMapperContext = typeof(CoreApplicationModule);
    }
}
