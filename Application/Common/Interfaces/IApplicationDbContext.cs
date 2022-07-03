using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; }
    public DbSet<Order> Orders { get; }
    public DbSet<OrderLine> OrderLines { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}