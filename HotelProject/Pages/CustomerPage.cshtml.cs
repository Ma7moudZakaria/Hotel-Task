using HotelDomain.Features.CQRS.Commands;
using HotelProject.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HotelProject.Pages;

public class CustomerPageModel : PageModel
{
    private readonly IMediator _mediator;

    public CustomerPageModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty] public CustomerViewModel CustomerModel { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
    {
        var customerRequest = new HotelDomain.Features.DTO.Commands.CustomerDTO
        {
            Name = CustomerModel.Name,
            Email = CustomerModel.Email,
            Address = CustomerModel.Address,
            Phone = CustomerModel.Phone,
            DateOfBirth = CustomerModel.DateOfBirth
        };

        TempData["CustomerModel"] = JsonSerializer.Serialize(customerRequest);

        await _mediator.Send(new CustomerCommand() { CustomerRequest = customerRequest }, cancellationToken);

        return RedirectToPage("/RoomPage", cancellationToken);
    }
}