namespace Application.Interfaces.Queries;

public interface IQueryHandler<in TQuery, TResponse> : IQuery<TResponse>
{
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
}