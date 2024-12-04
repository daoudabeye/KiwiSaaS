namespace Kiwi.Core;

public static class CoreDbProperties
{
    public static string DbTablePrefix { get; set; } = "Core";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Core";
    public const string LiteDbConnectionName = "CoreLitDb";
}
