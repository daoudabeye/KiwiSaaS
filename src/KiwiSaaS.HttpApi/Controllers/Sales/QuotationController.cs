using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KiwiSaaS.Sales.Application;
using KiwiSaaS.Sales.Application.Contracts;
using KiwiSaaS.Meta.Application.Meta;
using KiwiSaaS.Meta.Domain.Services;

namespace KiwiSaaS.HttpApi.Controllers.Sales;

[ApiController]
[Route("api/sales/quotations")] 
public class QuotationController : ControllerBase
{
    // NOTE: For now, avoid DI wiring by composing minimal services directly.
    private static readonly IAutoNumberService AutoNumberService = new AutoNumberService();
    private static readonly QuotationAppService App = new(AutoNumberService);

    [HttpGet]
    public ActionResult<List<QuotationDto>> List()
    {
        return Ok(App.List());
    }

    [HttpGet("{id}")]
    public ActionResult<QuotationDto> Get(Guid id)
    {
        var dto = App.Get(id);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public ActionResult<QuotationDto> Create([FromBody] CreateQuotationInput input)
    {
        var dto = App.Create(input);
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public ActionResult<QuotationDto> Update(Guid id, [FromBody] UpdateQuotationInput input)
    {
        var dto = App.Update(id, input);
        return dto is null ? NotFound() : Ok(dto);
    }
}
