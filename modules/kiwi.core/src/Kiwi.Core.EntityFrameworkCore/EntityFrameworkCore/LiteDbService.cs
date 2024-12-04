using LiteDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;

namespace Kiwi.Core.EntityFrameworkCore;

[ConnectionStringName(CoreDbProperties.LiteDbConnectionName)]
public class LiteDbService: ILiteDbService
{
    public LiteDatabase Database { get; }
    
    public LiteDbService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LiteDbConnection");
        Database = new LiteDatabase(connectionString);
    }
}

public static class LiteDbServiceExtensions
{
    public static IServiceCollection AddLiteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<LiteDbService>();
        return services;
    }
}
