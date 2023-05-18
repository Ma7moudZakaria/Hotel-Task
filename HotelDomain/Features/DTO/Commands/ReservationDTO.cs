namespace HotelDomain.Features.DTO.Commands;

public class ReservationDTO
{
    public DateTime ReservationDate { get; set; }
    public string CustomerName { get; set; }
    public int NumberOfNights { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid RoomId { get; set; }
}