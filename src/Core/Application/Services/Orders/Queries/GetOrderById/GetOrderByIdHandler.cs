using Domain;
using AutoMapper;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Orders.Queries.GetOrderById;

public class GetOrderByIdHandler : IQueryHandler<GetOrderById, OrderResponse>
{
    private readonly IOrdersDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderByIdHandler(IOrdersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<OrderResponse> Handle(GetOrderById query, CancellationToken cancellationToken = default(CancellationToken))
    {
        var order = await _context.Orders
            .Include(order => order.Lines)
            .FirstOrDefaultAsync(order => order.Id == query.Id, cancellationToken);
        
        if (order is null)
            throw new NotFoundException(nameof(Order), query.Id);
        
        return _mapper.Map<OrderResponse>(order);
    }
}