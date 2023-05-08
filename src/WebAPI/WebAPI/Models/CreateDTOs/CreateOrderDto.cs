using AutoMapper;
using Application.Common.Mappings;
using Application.Services.Orders.Commands.CreateOrder;

namespace WebAPI.Models.CreateDTOs;

public class CreateOrderDto : IMapWith<CreateOrderCommand>
{
    public Guid Id { get; set; }
    public ICollection<CreateLineDto> Lines { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
            .ForMember(command => command.Id, options => options
                .MapFrom(dto => dto.Id))
            .ForMember(command => command.Lines, options => options
                .MapFrom(dto => dto.Lines));
    }
}