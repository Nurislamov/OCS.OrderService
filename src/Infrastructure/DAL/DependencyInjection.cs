using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DependencyInjection
{
    public static IServiceCollection OrdersDbContext(this IServiceCollection services, string? connectionString)
    {
        return services.AddDbContext<OrdersDbContext>(options => options.UseNpgsql(connectionString));
    }

    public static IServiceCollection AddOrderRepository(this IServiceCollection services)
    {
        return services.AddScoped<IOrdersDbContext, OrdersDbContext>();
    } 
}