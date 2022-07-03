using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Orders.Commands;

public class CreateOrderCommand : IRequest<Guid>
{
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string Reference { get; set; }
    public string CustomerName { get; set; }
    public Guid UserId { get; set; }
    public List<OrderLineDtoShort> Lines { get; set; }
    
}
public class OrderLineDtoShort
{
    public string ItemCode { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        
        // create and add order
        var order = new Order()
        {
            OrderNumber = request.OrderNumber,
            OrderDate = request.OrderDate,
            Reference = request.Reference,
            CustomerName = request.CustomerName,
            UserId = request.UserId
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);
        
        
        // create and add order lines
        var lines = new List<OrderLine>();
        var lineNumber = 1;
        foreach (var orderLine in request.Lines)
        {
            var entity = new OrderLine
            {
                OrderId = order.Id,
                Quantity = orderLine.Quantity,
                Price = orderLine.Price,
                ItemCode = orderLine.ItemCode,
                LineNumber = lineNumber++
            };
            _context.OrderLines.Add(entity);
            lines.Add(entity);
        }
        await _context.SaveChangesAsync(cancellationToken);
        return order.Id;
    }
}