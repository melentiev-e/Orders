using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Order : BaseAuditableEntity
{
    public int OrderNumber { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [MaxLength(250)]
    public string Reference { get; set; }
    [MaxLength(500)]
    [Required]
    public string CustomerName { get; set; }
    
    public List<OrderLine> Lines { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}