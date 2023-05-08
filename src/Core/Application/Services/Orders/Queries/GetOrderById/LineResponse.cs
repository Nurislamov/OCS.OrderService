using Domain;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.Services.Orders.Queries.GetOrderById;

public class LineResponse : IMapWith<Line>
{
    public Guid Id { get; set; }
    public int Qty { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Line, LineResponse>()
            .ForMember(response => response.Id, options => options
                .MapFrom(order => order.ProductId))
            .ForMember(response => response.Qty, options => options
                .MapFrom(order => order.Quantity));
    }
}