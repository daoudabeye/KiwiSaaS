using System;
using System.Collections.Generic;

namespace KiwiSaaS.Meta.Application.Contracts.Meta;

public record EntityMetaDto
(
    Guid Id,
    string Name,
    string Label,
    string LabelPlural,
    string Color,
    string IconClass,
    bool System,
    Guid? RecordScreenIdField,
    string? RecordPermissionsJson
);

public record FieldMetaDto
(
    Guid Id,
    Guid EntityMetaId,
    string Name,
    string Label,
    int Type,
    bool Required,
    bool Unique,
    bool Searchable,
    bool EnableSecurity,
    string? FieldPermissionsJson,
    string? DefaultValueJson,
    string? PlaceholderText,
    string? HelpText,
    bool System
);

public record AutoNumberSequenceDto
(
    Guid Id,
    Guid? TenantId,
    string EntityName,
    string FieldName,
    string DisplayFormat,
    long StartingNumber,
    long Current
);

public record CreateEntityMetaInput
(
    string Name,
    string Label,
    string LabelPlural,
    string Color,
    string IconClass,
    bool System,
    Guid? RecordScreenIdField,
    string? RecordPermissionsJson
);

public record UpdateEntityMetaInput
(
    string Label,
    string LabelPlural,
    string Color,
    string IconClass,
    bool System,
    Guid? RecordScreenIdField,
    string? RecordPermissionsJson
);

public record CreateFieldMetaInput
(
    Guid EntityMetaId,
    string Name,
    string Label,
    int Type,
    bool Required,
    bool Unique,
    bool Searchable,
    bool EnableSecurity,
    string? FieldPermissionsJson,
    string? DefaultValueJson,
    string? PlaceholderText,
    string? HelpText,
    bool System
);

public record UpdateFieldMetaInput
(
    string Label,
    int Type,
    bool Required,
    bool Unique,
    bool Searchable,
    bool EnableSecurity,
    string? FieldPermissionsJson,
    string? DefaultValueJson,
    string? PlaceholderText,
    string? HelpText,
    bool System
);
