using Application.Interfaces.Queries;

namespace Application.Services.Orders.Queries;

public class QueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
{
    private readonly IQueryHandler<TQuery, TResponse> _decorated;

    public QueryHandler(IQueryHandler<TQuery, TResponse> decorated) => _decorated = decorated;

    public async Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _decorated.Handle(query, cancellationToken);
    }
}