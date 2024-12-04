using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace Kiwi.Core.MetaData;

public class MetaRelation : ValueObject
{
    public Guid SourceEntityId { get; set; }
    public MetaEntity SourceEntity { get; set; }
    public Guid TargetEntityId { get; set; }
    public MetaEntity TargetEntity { get; set; }
    public RelationType RelationType { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return SourceEntityId;
        yield return TargetEntityId;
        yield return RelationType;
        yield return SourceEntity;
        yield return TargetEntity;
        yield return RelationType;
    }
}
