using System.Collections.Concurrent;
using KiwiSaaS.Meta.Domain.Services;

namespace KiwiSaaS.Meta.Application.Meta;

public class AutoNumberService : IAutoNumberService
{
    private static readonly ConcurrentDictionary<string, long> Sequences = new();

    public string GetNext(string entityName, string fieldName, Guid? tenantId = null, string? displayFormat = null, long? startingNumber = null)
    {
        var key = $"{tenantId?.ToString() ?? "_"}:{entityName}:{fieldName}";
        var start = startingNumber ?? 1;
        var next = Sequences.AddOrUpdate(key, start, (_, current) => current + 1);
        var fmt = displayFormat ?? "{0}";
        return Format(fmt, next);
    }

    private static string Format(string template, long value)
    {
        // Support tokens {yyyy}, {MM}, {dd} and numeric padding like {000000}
        var now = DateTime.UtcNow;
        template = template.Replace("{yyyy}", now.Year.ToString());
        template = template.Replace("{MM}", now.Month.ToString("00"));
        template = template.Replace("{dd}", now.Day.ToString("00"));

        // Handle {0}, {000}, etc.
        if (template.Contains("{0}")) return string.Format(template, value);

        // numeric padding pattern
        var padLen = DetectPadding(template);
        var padded = value.ToString(new string('0', padLen));
        return template.Replace("{" + new string('0', padLen) + "}", padded);
    }

    private static int DetectPadding(string template)
    {
        // naive: search longest run like {000000}
        var max = 1;
        for (int i = 6; i >= 1; i--)
        {
            if (template.Contains("{" + new string('0', i) + "}")) return i;
        }
        return max;
    }
}
