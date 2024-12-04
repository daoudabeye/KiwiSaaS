using KiwiSaaS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace KiwiSaaS.Permissions;

public class KiwiSaaSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(KiwiSaaSPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(KiwiSaaSPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<KiwiSaaSResource>(name);
    }
}