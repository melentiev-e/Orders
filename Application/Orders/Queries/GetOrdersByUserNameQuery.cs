using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Queries;

public class GetOrdersByUserNameQuery : IRequest<List<OrderDto>>
{
    public string UserName { get; set; }
}

public class GetOrdersByUserNameQueryHandler : IRequestHandler<GetOrdersByUserNameQuery, List<OrderDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrdersByUserNameQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> Handle(GetOrdersByUserNameQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.UserName))
        {
           return await _context.Orders.AsNoTracking()
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
        
        var orders = await _context.Orders.AsNoTracking()
            .Where(e => e.User.UserName == request.UserName)
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
        return orders;
    }
}
