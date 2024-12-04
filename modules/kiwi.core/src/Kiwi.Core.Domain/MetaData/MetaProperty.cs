using System;
using Volo.Abp.Domain.Entities;

namespace Kiwi.Core.MetaData;

public class MetaProperty : Entity<Guid>
{
    public Guid MetaEntityId { get; set; }

    public string Name { get; set; }

    public string Label { get; set; }

    public string PlaceholderText { get; set; }

    public string Description { get; set; }

    public string HelpText { get; set; }

    public bool Required { get; set; }

    public bool Unique { get; set; }

    public bool Searchable { get; set; }

    public bool Auditable { get; set; }

    public bool System { get; set; }

    public PropertyPermissions Permissions { get; set; }

    public bool EnableSecurity { get; set; }
}
