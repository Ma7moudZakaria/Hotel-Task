using HotelDomain.Features.CQRS.Commands;
using HotelDomain.Features.DTO.Commands;
using HotelProject.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HotelProject.Pages;

public class RoomPageModel : PageModel
{
    private readonly IMediator _mediator;

    public RoomPageModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty] public RoomViewModel RoomModel { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
    {
        var roomRequest = new HotelDomain.Features.DTO.Commands.RoomDTO
        {
            Id = Guid.NewGuid(),
            Floor = RoomModel.Floor,
            NumberOfBeds = RoomModel.NumberOfBeds,
            PricePerNight = RoomModel.PricePerNight,
            RoomNumber = RoomModel.RoomNumber,
            RoomType = RoomModel.RoomType
        };

        await _mediator.Send(new RoomCommand() { RoomRequest = roomRequest }, cancellationToken);
        var customerModel = JsonSerializer.Deserialize<CustomerDTO>(TempData["CustomerModel"].ToString());
        var Data = new 
        {
            Name = customerModel.Name,
            Email = customerModel.Email,
            Phone = customerModel.Phone,
            Address = customerModel.Address,
            RoomType = RoomModel.RoomType,
            RoomNumber = roomRequest.RoomNumber,
            ReservationDate = DateTime.UtcNow,
            NumberOfNights = RoomModel.NumberOfBeds
        };

        return RedirectToPage("/ReservationPage", Data);
    }
}
