using AutoMapper;
using Application.Common.Mappings;
using Application.Services.Orders.Commands.UpdateOrder;

namespace WebAPI.Models.UpdateDTOs;

public class UpdateLineDto : IMapWith<UpdateLineCommand>
{
    public Guid Id { get; set; }
    public int Qty { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateLineDto, UpdateLineCommand>()
            .ForMember(command => command.Id, options => options
                .MapFrom(dto => dto.Id))
            .ForMember(command => command.Qty, options => options
                .MapFrom(dto => dto.Qty));
    }
}