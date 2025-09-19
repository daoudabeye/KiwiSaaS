namespace KiwiSaaS.Meta.Domain.Entities;

public class FieldMeta
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid EntityMetaId { get; set; }
    public string Name { get; set; } = string.Empty;    // developer name
    public string Label { get; set; } = string.Empty;   // display label
    public FieldType Type { get; set; }                 // field type
        = FieldType.Text;
    public bool Required { get; set; }
    public bool Unique { get; set; }
    public bool Searchable { get; set; }
    public bool EnableSecurity { get; set; }
    public string? FieldPermissionsJson { get; set; }
    public string? DefaultValueJson { get; set; }
    public string? PlaceholderText { get; set; }
    public string? HelpText { get; set; }
    public bool System { get; set; }
}

public enum FieldType
{
    Text = 0,
    Number = 1,
    Currency = 2,
    Percent = 3,
    Date = 4,
    DateTime = 5,
    Email = 6,
    Url = 7,
    Checkbox = 8,
    Select = 9,
    Multiselect = 10,
    File = 11,
    Image = 12,
    Html = 13,
    Guid = 14,
    Autonumber = 15,
    Password = 16
}
