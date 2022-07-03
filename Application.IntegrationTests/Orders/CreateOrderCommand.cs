using Application.Orders.Commands;
using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Application.IntegrationTests.Orders;
using static Testing;
public class CreateOrderCommand : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateUser()
    {
        var user = new User()
        {
            FullName = "Test User",
            UserName = "u3",
            Password = "123"

        };
        await AddAsync(user);
        var order = await SendAsync(new Application.Orders.Commands.CreateOrderCommand()
        {
            UserId = user.Id,
            Reference = "ref",
            CustomerName = "name",
            OrderDate = DateTime.Now,
            OrderNumber = 11,
            Lines = new List<OrderLineDtoShort>
            {
                new OrderLineDtoShort()
                {
                    Price = 300,
                    Quantity = 100,
                    ItemCode = "test"
                }
            }
        });
    
        var item = await FindAsync<Order>(order);

        item.Should().NotBeNull();
    }
}