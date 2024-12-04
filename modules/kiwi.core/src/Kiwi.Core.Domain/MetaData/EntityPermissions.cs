using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace Kiwi.Core.MetaData;

public class EntityPermissions: ValueObject
{
    public List<Guid> CanRead { get; set; } = new List<Guid>();

    public List<Guid> CanCreate { get; set; } = new List<Guid>();

    public List<Guid> CanUpdate { get; set; } = new List<Guid>();

    public List<Guid> CanDelete { get; set; } = new List<Guid>();

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CanRead;
        yield return CanCreate;
        yield return CanUpdate;
        yield return CanDelete;
    }
}
