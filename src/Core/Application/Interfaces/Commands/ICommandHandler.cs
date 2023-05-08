namespace Application.Interfaces.Commands;

public interface ICommandHandler<in TCommand>
{
    Task Handle(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
}