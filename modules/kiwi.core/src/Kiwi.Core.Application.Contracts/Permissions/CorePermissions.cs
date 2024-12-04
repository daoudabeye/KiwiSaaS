using Volo.Abp.Reflection;

namespace Kiwi.Core.Permissions;

public class CorePermissions
{
    public const string GroupName = "Core";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CorePermissions));
    }
}
