using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Services.Orders.Commands.CreateOrder;
using Application.Services.Orders.Commands.DeleteOrder;
using Application.Services.Orders.Commands.UpdateOrder;
using Application.Services.Orders.Queries.GetOrderById;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static  class DependencyInjection
{
    public static IServiceCollection AddOrdersCommandsService(this IServiceCollection services)
    {
        return services
            .AddScoped<ICommandHandler<CreateOrderCommand>, CreateOrderHandler>()
            .AddScoped<ICommandHandler<UpdateOrderCommand>, UpdateOrderHandler>()
            .AddScoped<ICommandHandler<DeleteOrderCommand>, DeleteOrderHandler>();
    }
    
    public static IServiceCollection AddOrdersQueriesService(this IServiceCollection services)
    {
        return services.AddScoped<IQueryHandler<GetOrderById, OrderResponse>, GetOrderByIdHandler>();
    }
}