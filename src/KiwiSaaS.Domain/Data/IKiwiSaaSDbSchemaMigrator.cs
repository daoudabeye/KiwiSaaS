using System.Threading.Tasks;

namespace KiwiSaaS.Data;

public interface IKiwiSaaSDbSchemaMigrator
{
    Task MigrateAsync();
}
