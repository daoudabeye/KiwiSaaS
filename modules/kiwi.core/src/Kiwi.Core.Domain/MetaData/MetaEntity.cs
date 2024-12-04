using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kiwi.Core.MetaData;

public class MetaEntity : FullAuditedAggregateRoot<Guid> //, IMongoEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Label { get; set; }

    public string LabelPlural { get; set; }

    public bool System { get; set; }

    public string IconName { get; set; }

    public string Color { get; set; }

    public EntityPermissions RecordPermissions { get; set; } = new EntityPermissions();

    public Guid? RecordScreenIdField { get; set; } //If null the ID field of the record is used as Sc

    public ICollection<MetaProperty> Properties { get; set; } = new List<MetaProperty>();
    public ICollection<MetaRelation> Relations { get; set; } = new List<MetaRelation>();
}
