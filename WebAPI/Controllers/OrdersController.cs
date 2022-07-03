using System.Runtime.InteropServices;
using Application.Orders.Commands;
using Application.Orders.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class OrdersController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateOrderCommand command)
    {
        return await Mediator.Send(command);
    }
    
    [HttpGet("{userName}")]
    public async Task<ActionResult<List<OrderDto>>> Get(string userName)
    {
        var query = new GetOrdersByUserNameQuery
        {
            UserName = userName
        };
        return await Mediator.Send(query);
    }
    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> Get()
    {
        var query = new GetOrdersByUserNameQuery();
        return await Mediator.Send(query);
    }
    
    

}
