using HotelDomain.Features.DTO.Commands;
using MediatR;

namespace HotelDomain.Features.CQRS.Commands;

public class ReservationCommand : IRequest<int>
{
    public ReservationDTO ReservationRequest { get; set; }
}