using System;

namespace KiwiSaaS.Purchase.Domain;

public enum PurchaseOrderStatus
{
    Draft = 0,
    Ordered = 1,
    Received = 2,
    Cancelled = 3
}

public class PurchaseOrder
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? TenantId { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public Guid SupplierId { get; set; }
    public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Draft;
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
}

public class PurchaseOrderLine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PurchaseOrderId { get; set; }
    public Guid ProductId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TaxRate { get; set; }
    public decimal LineTotal { get; set; }
}

public class GoodsReceipt
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PurchaseOrderId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
