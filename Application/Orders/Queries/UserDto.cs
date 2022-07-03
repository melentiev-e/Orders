using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Orders.Queries;

public class UserDto : IMapFrom<User>
{
    public string UserName { get; set; }
    public string FullName { get; set; }
}