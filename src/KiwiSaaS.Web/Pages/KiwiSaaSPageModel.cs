using KiwiSaaS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KiwiSaaS.Web.Pages;

public abstract class KiwiSaaSPageModel : AbpPageModel
{
    protected KiwiSaaSPageModel()
    {
        LocalizationResourceType = typeof(KiwiSaaSResource);
    }
}
