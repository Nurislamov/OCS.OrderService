using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IOrdersDbContext
{
    DbSet<Order> Orders { get; set; }
    DbSet<Line> Lines { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}