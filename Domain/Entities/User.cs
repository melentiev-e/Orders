using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User : BaseAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [MaxLength(500)]
    public string FullName { get; set; }
}