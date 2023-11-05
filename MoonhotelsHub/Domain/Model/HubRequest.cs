namespace MoonhotelsHub.Domain.Model
{
    public class HubRequest
    {
        public int HotelId { get; set; }
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfRooms { get; set; }
        public string Currency { get; set; } = string.Empty;
    }

}