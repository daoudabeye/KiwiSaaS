using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KiwiSaaS.Meta.Domain.Entities;
using KiwiSaaS.Meta.Application.Meta;
using KiwiSaaS.Meta.Application.Contracts.Meta;

namespace KiwiSaaS.Meta.HttpApi.Controllers;

[ApiController]
[Route("api/meta")] 
public class MetaController : ControllerBase
{
    [HttpGet("entities")] 
    public ActionResult<IEnumerable<EntityMetaDto>> GetEntities()
    {
        var list = new List<EntityMetaDto>();
        foreach (var e in MetaRepository.Entities.Values)
        {
            list.Add(new EntityMetaDto(e.Id, e.Name, e.Label, e.LabelPlural, e.Color, e.IconClass, e.System, e.RecordScreenIdField, e.RecordPermissionsJson));
        }
        return Ok(list);
    }

    [HttpPost("entities")] 
    public ActionResult<EntityMetaDto> CreateEntity([FromBody] CreateEntityMetaInput input)
    {
        var entity = new EntityMeta
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Label = input.Label,
            LabelPlural = input.LabelPlural,
            Color = input.Color,
            IconClass = input.IconClass,
            System = input.System,
            RecordScreenIdField = input.RecordScreenIdField,
            RecordPermissionsJson = input.RecordPermissionsJson
        };
        MetaRepository.Entities[entity.Id] = entity;
        var dto = new EntityMetaDto(entity.Id, entity.Name, entity.Label, entity.LabelPlural, entity.Color, entity.IconClass, entity.System, entity.RecordScreenIdField, entity.RecordPermissionsJson);
        return CreatedAtAction(nameof(GetEntities), new { id = entity.Id }, dto);
    }
}
