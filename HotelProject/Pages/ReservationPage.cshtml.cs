using HotelDomain.Features.DTO.Commands;
using HotelProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Numerics;

namespace HotelProject.Pages
{
    public class ReservationPageModel : PageModel
    {
        public ReservationModel ReservationModel { get; set; }

        public void OnGet(ReservationModel reservationModel)
        {
            ReservationModel = new ReservationModel
            {
                Name = reservationModel.Name,
                Email = reservationModel.Email,
                Phone = reservationModel.Phone,
                Address = reservationModel.Address,
                RoomType = reservationModel.RoomType,
                RoomNumber = reservationModel.RoomNumber,
                ReservationDate = reservationModel.ReservationDate,
                NumberOfNights = reservationModel.NumberOfNights
            };
        }
    }
}
