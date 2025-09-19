namespace KiwiSaaS.Meta.Domain.Entities;

public class EntityMeta
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;          // developer name
    public string Label { get; set; } = string.Empty;         // singular
    public string LabelPlural { get; set; } = string.Empty;   // plural
    public string Color { get; set; } = string.Empty;         // UI hint
    public string IconClass { get; set; } = string.Empty;     // UI icon
    public bool System { get; set; }                          // lock admin modifications
        = false;
    public Guid? RecordScreenIdField { get; set; }            // field used as record header
        = null;
    public string? RecordPermissionsJson { get; set; }        // serialized policy (role->CRUD)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}
