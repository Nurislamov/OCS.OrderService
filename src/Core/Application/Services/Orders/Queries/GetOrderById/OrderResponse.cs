using Domain;
using AutoMapper;
using Application.Common.Mappings;
using Application.Common.Extensions;

namespace Application.Services.Orders.Queries.GetOrderById;

public class OrderResponse : IMapWith<Order>
{
    public OrderResponse() => Lines = new List<LineResponse>();
    
    public Guid Id { get; set; }
    public string Status { get; set; } = null!;
    public string CreatedDateTime { get; set; } = null!;
    public List<LineResponse> Lines { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderResponse>()
            .ForMember(response => response.Id, options => options
                .MapFrom(order => order.Id))
            .ForMember(response => response.Status, options => options
                .MapFrom(order => order.Status))
            .ForMember(response => response.CreatedDateTime, options => options
                .MapFrom(order => order.CreatedDateTime.GetDateTimeForView()))
            .ForMember(response => response.Lines, options => options
                .MapFrom(order => order.Lines));
    }
}