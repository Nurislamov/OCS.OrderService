using Domain;
using Application.Common.Exceptions;
using Application.Common.Extensions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Orders.Commands.UpdateOrder;

public class UpdateOrderHandler : ICommandHandler<UpdateOrderCommand>
{
    private readonly IOrdersDbContext _context;

    public UpdateOrderHandler(IOrdersDbContext context)
        => _context = context;

    public async Task Handle(UpdateOrderCommand command, CancellationToken cancellationToken = default(CancellationToken))
    {
        if (!command.IsUpdateOrderValid())
            return;
        
        var newUpdateOrder = await _context.Orders
            .FirstOrDefaultAsync(order => order.Id == command.Id, cancellationToken);
        if (newUpdateOrder is null)
            throw new NotFoundException(nameof(Order), command.Id);
        
        if (!newUpdateOrder.Status.IsCanChangeStatus())
            return;
        newUpdateOrder.Status = Enum.Parse<Status>(command.Status);
        _context.Orders.Update(newUpdateOrder);
        
        var updateLines = await _context.Lines
            .Where(line => line.OrderId == newUpdateOrder.Id)
            .ToListAsync(cancellationToken);
        _context.Lines.RemoveRange(updateLines);
        await _context.SaveChangesAsync(cancellationToken);
        
        updateLines = command.Lines.Select(line =>
            new Line
            {
                ProductId = line.Id,
                Quantity = line.Qty,
                OrderId = newUpdateOrder.Id
            }).ToList();
        _context.Lines.AddRange(updateLines);
        await _context.SaveChangesAsync(cancellationToken);
    }
}