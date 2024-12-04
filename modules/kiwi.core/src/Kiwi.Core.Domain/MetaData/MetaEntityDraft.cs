using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kiwi.Core.MetaData;

public class MetaEntityDraft : FullAuditedAggregateRoot<Guid>
{
    public Guid MetaEntityId { get; set; }
    public MetaEntity MetaEntity { get; set; }
    public string DraftData { get; set; }
}
