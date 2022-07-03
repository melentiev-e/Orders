using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class ApplicationDBContextInitialiser
{
    
    private readonly ILogger<ApplicationDBContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    
    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }
    
    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
    
    public async Task TrySeedAsync()
    {
       

        // Default users
        var administrator = new User() { UserName = "admin", FullName = "Administrator", Password = "admin"};

        if (_context.Users.All(u => u.UserName != administrator.UserName))
        {
            _context.Users.Add(administrator);
            await _context.SaveChangesAsync();
        }

        // Default data
        // Seed, if necessary
        if (!_context.Orders.Any())
        {
            _context.Orders.Add(new Order()
            {
                OrderDate = DateTime.Parse("01/01/2019"),
                Reference = "My first order",
                CustomerName = "John Doe",
                User = administrator,
                OrderNumber = 112,
                Lines = 
                {
                    new OrderLine { ItemCode = "Item Code 1", Quantity = 10, Price  = 10.30m, LineNumber = 1},
                    new OrderLine { ItemCode = "Item Code 2", Quantity = 11, Price  = 110.30m, LineNumber = 2},
                    new OrderLine { ItemCode = "Item Code 3", Quantity = 12, Price  = 120.30m, LineNumber = 3},
                    new OrderLine { ItemCode = "Item Code 4", Quantity = 13, Price  = 130.30m, LineNumber = 4},
                    new OrderLine { ItemCode = "Item Code 5", Quantity = 14, Price  = 140.30m, LineNumber = 5},
                    new OrderLine { ItemCode = "Item Code 6", Quantity = 15, Price  = 150.30m, LineNumber = 6},
                    new OrderLine { ItemCode = "Item Code 7", Quantity = 16, Price  = 10.360m, LineNumber = 7},
                    new OrderLine { ItemCode = "Item Code 8", Quantity = 17, Price  = 10.350m, LineNumber = 8},
                    new OrderLine { ItemCode = "Item Code 9", Quantity = 108, Price  = 10.304m, LineNumber = 9},
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}