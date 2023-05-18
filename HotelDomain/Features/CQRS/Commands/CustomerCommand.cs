using HotelDomain.Features.DTO.Commands;
using MediatR;

namespace HotelDomain.Features.CQRS.Commands;

public class CustomerCommand : IRequest<int>
{
    public CustomerDTO CustomerRequest { get; set; }
}