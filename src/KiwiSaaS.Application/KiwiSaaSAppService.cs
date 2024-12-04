using KiwiSaaS.Localization;
using Volo.Abp.Application.Services;

namespace KiwiSaaS;

/* Inherit your application services from this class.
 */
public abstract class KiwiSaaSAppService : ApplicationService
{
    protected KiwiSaaSAppService()
    {
        LocalizationResource = typeof(KiwiSaaSResource);
    }
}
