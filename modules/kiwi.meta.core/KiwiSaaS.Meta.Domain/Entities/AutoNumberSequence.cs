namespace KiwiSaaS.Meta.Domain.Entities;

public class AutoNumberSequence
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? TenantId { get; set; }
    public string EntityName { get; set; } = string.Empty;   // e.g., Sales.Quotation
    public string FieldName { get; set; } = string.Empty;    // e.g., Number
    public string DisplayFormat { get; set; } = "{0}";       // e.g., QUO-{yyyy}-{000000}
    public long StartingNumber { get; set; } = 1;
    public long Current { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}
