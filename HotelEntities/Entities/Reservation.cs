using HotelEntities.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelEntities.Entities;

public class Reservation : BaseEntity
{
    public DateTime ReservationDate { get; set; }    
    public string CustomerName { get; set; }
    public int NumberOfNights { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid RoomId { get; set; }
    [ForeignKey(nameof(RoomId))] public Room Room { get; set; }
}