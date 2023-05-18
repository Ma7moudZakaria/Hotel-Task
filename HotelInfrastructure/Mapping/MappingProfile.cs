using AutoMapper;
using HotelDomain.Features.DTO.Commands;
using HotelEntities.Entities;

namespace HotelInfrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerDTO, Customer>().ForMember(dest => dest.Id, opt => opt.MapFrom((src) => Guid.NewGuid()));
        CreateMap<RoomDTO, Room>();
        CreateMap<ReservationDTO, Reservation>().ForMember(dest => dest.Id, opt => opt.MapFrom((src) => Guid.NewGuid()));
    }
}