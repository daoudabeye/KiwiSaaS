using System.Collections.Concurrent;
using KiwiSaaS.Meta.Domain.Entities;

namespace KiwiSaaS.Meta.Application.Meta;

public static class MetaRepository
{
    public static readonly ConcurrentDictionary<Guid, EntityMeta> Entities = new();
    public static readonly ConcurrentDictionary<Guid, FieldMeta> Fields = new();
}
