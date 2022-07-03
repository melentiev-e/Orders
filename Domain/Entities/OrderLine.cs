using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class OrderLine : BaseAuditableEntity
{
    public int LineNumber { get; set; }
    [MaxLength(250)]
    [Required]
    public string ItemCode { get; set; }
    [Column(TypeName = "decimal(18,3)")]
    [Required]
    public decimal Quantity { get; set; }
    [Column(TypeName = "decimal(18,9)")]
    [Required]
    public decimal Price { get; set; }
    public Order Order { get; set; }
    public Guid OrderId { get; set; }
   
}