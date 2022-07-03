using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Application.IntegrationTests.Users;
using static Testing;
public class CreateUserCommand : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateUser()
    {

        var userId = await SendAsync(new Application.Users.Commands.CreateUserCommand()
        {
             Password = "1",
             FullName = "fullName",
             UserName = "userName"
        });
    
        var item = await FindAsync<User>(userId);

        item.Should().NotBeNull();
    }
}