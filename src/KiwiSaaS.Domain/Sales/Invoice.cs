using System;

namespace KiwiSaaS.Sales.Domain;

public enum InvoiceStatus
{
    Open = 0,
    Paid = 1,
    Cancelled = 2
}

public class Invoice
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? TenantId { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public Guid CustomerId { get; set; }
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Open;
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
}

public class InvoiceLine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TaxRate { get; set; }
    public decimal LineTotal { get; set; }
}
