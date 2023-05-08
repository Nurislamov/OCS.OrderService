using Domain;
using Application.Common.Extensions;
using Application.Interfaces;
using Application.Interfaces.Commands;

namespace Application.Services.Orders.Commands.CreateOrder;

public class CreateOrderHandler : ICommandHandler<CreateOrderCommand>
{
    private readonly IOrdersDbContext _context;

    public CreateOrderHandler(IOrdersDbContext context) => _context = context;
    
    public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken = default(CancellationToken))
    {
        if (!command.IsCreateOrderValid())
            return;

        var newOrder = new Order
        {
            Id = command.Id,
            Status = Status.New,
            CreatedDateTime = DateTime.UtcNow,
            Lines = command.Lines.Select(line =>
                new Line
                {
                    ProductId = line.Id,
                    Quantity = line.Qty,
                    OrderId = command.Id
                }).ToList()
        };

        if (cancellationToken.IsCancellationRequested) return;
        _context.Orders.Add(newOrder);
        await _context.SaveChangesAsync(cancellationToken);
    }
}