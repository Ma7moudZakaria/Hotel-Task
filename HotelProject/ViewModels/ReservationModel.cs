namespace HotelProject.ViewModels;

public class ReservationModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string RoomType { get; set; }
    public DateTime ReservationDate { get; set; }
    public int NumberOfNights { get; set; }
    public int RoomNumber { get; set; }
}