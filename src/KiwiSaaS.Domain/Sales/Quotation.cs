using System;

namespace KiwiSaaS.Sales.Domain;

public enum QuotationStatus
{
    Draft = 0,
    Sent = 1,
    Cancelled = 2
}

public class Quotation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? TenantId { get; set; }
    public string Number { get; set; } = string.Empty; // AutoNumber
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public Guid CustomerId { get; set; }
    public QuotationStatus Status { get; set; } = QuotationStatus.Draft;
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
}

public class QuotationLine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid QuotationId { get; set; }
    public Guid ProductId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TaxRate { get; set; }
    public decimal LineTotal { get; set; }
}
