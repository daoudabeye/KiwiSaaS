using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using KiwiSaaS.Localization;

namespace KiwiSaaS.Web;

[Dependency(ReplaceServices = true)]
public class KiwiSaaSBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<KiwiSaaSResource> _localizer;

    public KiwiSaaSBrandingProvider(IStringLocalizer<KiwiSaaSResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
