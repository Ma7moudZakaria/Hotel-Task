namespace HotelDomain.Features.DTO.Commands;

public class RoomDTO
{
    public Guid Id { get; set; }
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public int Floor { get; set; }
    public int NumberOfBeds { get; set; }
}