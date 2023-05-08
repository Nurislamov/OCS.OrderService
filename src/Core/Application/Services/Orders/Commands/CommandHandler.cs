using System.Transactions;
using Application.Interfaces.Commands;

namespace Application.Services.Orders.Commands;

public class CommandHandler<TCommand> : ICommandHandler<TCommand>
{
    private readonly ICommandHandler<TCommand> _decorated;
 
    public CommandHandler(ICommandHandler<TCommand> decorated) => _decorated = decorated;

    public async Task Handle(TCommand command, 
        CancellationToken cancellationToken = default(CancellationToken))
    {
        using var scope = new TransactionScope();
        
        if (cancellationToken.IsCancellationRequested) return;
        await _decorated.Handle(command, cancellationToken);
        
        scope.Complete();
    }
}