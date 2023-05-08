using Domain;
using Application.Interfaces;
using DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class OrdersDbContext : DbContext, IOrdersDbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Line> Lines { get; set; }
    
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
        : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new OrderConfiguration())
            .ApplyConfiguration(new LineConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}