using HotelDomain.Features.DTO.Commands;
using MediatR;

namespace HotelDomain.Features.CQRS.Commands;

public class RoomCommand : IRequest<int>
{
    public RoomDTO RoomRequest { get; set; }
}