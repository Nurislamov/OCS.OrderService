using Application.Interfaces.Queries;

namespace Application.Services.Orders.Queries.GetOrderById;

public class GetOrderById : IQuery<OrderResponse>
{
    public Guid Id { get; init; }
}