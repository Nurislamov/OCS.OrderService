using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Services.Orders.Commands.CreateOrder;
using Application.Services.Orders.Commands.DeleteOrder;
using Application.Services.Orders.Commands.UpdateOrder;
using Application.Services.Orders.Queries.GetOrderById;
using WebAPI.Models.CreateDTOs;
using WebAPI.Models.UpdateDTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ICommandHandler<CreateOrderCommand> _createHandler;
    private readonly ICommandHandler<UpdateOrderCommand> _updateHandler;
    private readonly ICommandHandler<DeleteOrderCommand> _deleteHandler;
    private readonly IQueryHandler<GetOrderById, OrderResponse> _getHandler;
    
    private readonly IMapper _mapper;
    
    public OrdersController(
        
        ICommandHandler<CreateOrderCommand> createHandler, 
        ICommandHandler<UpdateOrderCommand> updateHandler,
        ICommandHandler<DeleteOrderCommand> deleteHandler,
        IQueryHandler<GetOrderById, OrderResponse> getHandler,
        IMapper mapper)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task CreateOrder([Required]CreateOrderDto createOrderDto)
    {
        var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
        await _createHandler.Handle(command);
    }
    
    [HttpPut("/{id:guid}")]
    public async Task UpdateOrder(Guid id,[Required]UpdateOrderDto updateOrderDto)
    {
        updateOrderDto.Id = id;
        var command = _mapper.Map<UpdateOrderCommand>(updateOrderDto);
        await _updateHandler.Handle(command);
    }
    
    [HttpDelete("/{id:guid}")]
    public async Task DeleteOrder(Guid id)
    {
        var command = new DeleteOrderCommand { Id = id };
        await _deleteHandler.Handle(command);
    }
    
    [HttpGet("/{id:guid}")]
    public async Task<ActionResult<OrderResponse>> GetOrder(Guid id)
    {
        var query = new GetOrderById { Id = id };
        var order = await _getHandler.Handle(query);
        return Ok(order);
    }
}