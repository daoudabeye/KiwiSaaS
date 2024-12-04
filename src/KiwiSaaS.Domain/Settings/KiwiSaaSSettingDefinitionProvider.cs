using Volo.Abp.Settings;

namespace KiwiSaaS.Settings;

public class KiwiSaaSSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(KiwiSaaSSettings.MySetting1));
    }
}
