using Domain;
using Application.Interfaces;
using Application.Common.Exceptions;
using Application.Common.Extensions;
using Application.Interfaces.Commands;

namespace Application.Services.Orders.Commands.DeleteOrder;

public class DeleteOrderHandler : ICommandHandler<DeleteOrderCommand>
{
    private readonly IOrdersDbContext _context;

    public DeleteOrderHandler(IOrdersDbContext context) => _context = context;
    
    public async Task Handle(DeleteOrderCommand command, CancellationToken cancellationToken = default(CancellationToken))
    {
        var deletionOrder = await _context.Orders.FindAsync(new object?[] { command.Id }, cancellationToken);
        
        if (deletionOrder is null)
            throw new NotFoundException(nameof(Order), command.Id);
        if (!deletionOrder.Status.IsCanDelete())
            throw new NotCannotBeDeleted(nameof(DeleteOrderCommand), deletionOrder.Status);
        
        if (cancellationToken.IsCancellationRequested) return;
        _context.Orders.Remove(deletionOrder);
        await _context.SaveChangesAsync(cancellationToken);
    }
}