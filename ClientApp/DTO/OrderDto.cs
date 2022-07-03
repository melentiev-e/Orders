public class OrderDto 
{
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string Reference { get; set; }
    public string CustomerName { get; set; }
    public IList<OrderLineDto> Lines { get; set; }
    public UserDto User { get; set; }
    public Guid UserId { get; set; }
}