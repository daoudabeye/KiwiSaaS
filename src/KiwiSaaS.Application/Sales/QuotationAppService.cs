using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using KiwiSaaS.Sales.Application.Contracts;
using KiwiSaaS.Sales.Domain;
using KiwiSaaS.Meta.Application.Meta;
using KiwiSaaS.Meta.Domain.Services;

namespace KiwiSaaS.Sales.Application;

public class QuotationAppService
{
    private static readonly ConcurrentDictionary<Guid, Quotation> Store = new();
    private readonly IAutoNumberService _autoNumber;

    public QuotationAppService(IAutoNumberService autoNumber)
    {
        _autoNumber = autoNumber;
    }

    public QuotationDto Create(CreateQuotationInput input, Guid? tenantId = null)
    {
        var q = new Quotation
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            Number = _autoNumber.GetNext("Sales.Quotation", "Number", tenantId, "QUO-{yyyy}-{000000}"),
            Date = DateTime.UtcNow,
            CustomerId = input.CustomerId,
            Status = QuotationStatus.Draft,
        };

        var lines = input.Lines ?? new List<QuotationLineDto>();
        decimal subtotal = 0, tax = 0;
        foreach (var line in lines)
        {
            subtotal += line.Quantity * line.UnitPrice;
            tax += line.Quantity * line.UnitPrice * line.TaxRate;
        }
        q.Subtotal = subtotal;
        q.Discount = 0;
        q.Tax = tax;
        q.Total = subtotal - q.Discount + tax;

        Store[q.Id] = q;
        return ToDto(q, lines);
    }

    public QuotationDto? Get(Guid id)
    {
        return Store.TryGetValue(id, out var q) ? ToDto(q, new()) : null;
    }

    public List<QuotationDto> List()
    {
        return Store.Values.Select(x => ToDto(x, new())).ToList();
    }

    public QuotationDto? Update(Guid id, UpdateQuotationInput input)
    {
        if (!Store.TryGetValue(id, out var q)) return null;
        q.Status = (QuotationStatus)input.Status;
        // recompute totals if lines provided (simplified: ignore for now)
        Store[id] = q;
        return ToDto(q, input.Lines ?? new());
    }

    private static QuotationDto ToDto(Quotation q, List<QuotationLineDto> lines)
    {
        return new QuotationDto(
            q.Id,
            q.TenantId,
            q.Number,
            q.Date,
            q.CustomerId,
            (int)q.Status,
            q.Subtotal,
            q.Discount,
            q.Tax,
            q.Total,
            lines
        );
    }
}
