using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace KiwiSaaS.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class KiwiSaaSDbContextFactory : IDesignTimeDbContextFactory<KiwiSaaSDbContext>
{
    public KiwiSaaSDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        KiwiSaaSEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<KiwiSaaSDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));
        
        return new KiwiSaaSDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../KiwiSaaS.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
