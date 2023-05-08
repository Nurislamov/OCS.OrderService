using AutoMapper;
using Application.Common.Mappings;
using Application.Services.Orders.Commands.UpdateOrder;

namespace WebAPI.Models.UpdateDTOs;

public class UpdateOrderDto : IMapWith<UpdateOrderCommand>
{
    internal Guid Id { get; set; }
    public string Status { get; set; }
    public ICollection<UpdateLineDto> Lines { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>()
            .ForMember(command => command.Id, options => options
                .MapFrom(dto => dto.Id))
            .ForMember(command => command.Status, options => options
                .MapFrom(dto => dto.Status))
            .ForMember(command => command.Lines, options => options
                .MapFrom(dto => dto.Lines));
    }
}