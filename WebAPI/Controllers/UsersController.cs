using Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class UsersController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }
}