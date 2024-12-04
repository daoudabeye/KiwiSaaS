using KiwiSaaS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace KiwiSaaS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class KiwiSaaSController : AbpControllerBase
{
    protected KiwiSaaSController()
    {
        LocalizationResource = typeof(KiwiSaaSResource);
    }
}
