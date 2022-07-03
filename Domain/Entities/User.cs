using Domain.Common;

namespace Domain.Entities;

public class User : BaseAuditableEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
}