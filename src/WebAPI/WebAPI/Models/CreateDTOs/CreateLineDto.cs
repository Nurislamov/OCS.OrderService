using AutoMapper;
using Application.Common.Mappings;
using Application.Services.Orders.Commands.CreateOrder;

namespace WebAPI.Models.CreateDTOs;

public class CreateLineDto : IMapWith<CreateLineCommand>
{
    public Guid Id { get; set; }
    public int Qty { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateLineDto, CreateLineCommand>()
            .ForMember(command => command.Id, options => options
                .MapFrom(dto => dto.Id))
            .ForMember(command => command.Qty, options => options
                .MapFrom(dto => dto.Qty));
    }
}