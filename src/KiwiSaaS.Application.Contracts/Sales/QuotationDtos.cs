using System;
using System.Collections.Generic;

namespace KiwiSaaS.Sales.Application.Contracts;

public record QuotationLineDto
(
    Guid Id,
    Guid ProductId,
    string Description,
    decimal Quantity,
    decimal UnitPrice,
    decimal TaxRate,
    decimal LineTotal
);

public record QuotationDto
(
    Guid Id,
    Guid? TenantId,
    string Number,
    DateTime Date,
    Guid CustomerId,
    int Status,
    decimal Subtotal,
    decimal Discount,
    decimal Tax,
    decimal Total,
    List<QuotationLineDto> Lines
);

public record CreateQuotationInput
(
    Guid CustomerId,
    List<QuotationLineDto> Lines
);

public record UpdateQuotationInput
(
    int Status,
    List<QuotationLineDto> Lines
);
