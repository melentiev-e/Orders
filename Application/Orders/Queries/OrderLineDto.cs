using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Orders.Queries;

public class OrderLineDto : IMapFrom<OrderLine>{
    public int LineNumber { get; set; }
    public string ItemCode { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}