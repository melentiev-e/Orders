using Domain.Common;

namespace Domain.Entities;

public class Order : BaseAuditableEntity
{
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string Reference { get; set; }
    public string CustomerName { get; set; }
    public User UserId { get; set; }
}