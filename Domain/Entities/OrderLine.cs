using Domain.Common;

namespace Domain.Entities;

public class OrderLine : BaseAuditableEntity
{
    public int LineNumber { get; set; }
    public string ItemCode { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public Order Order { get; set; }
}