namespace MoonhotelsHub.Infrastructure.Apis.HotelLegs
{
    public class HotelLegsRequest
    {
        public int Hotel { get; set; }
        public DateOnly CheckInDate { get; set; }
        public int NumberOfNights { get; set; }
        public int Guests { get; set; }
        public int Rooms { get; set; }
        public string Currency { get; set; } = string.Empty;

    }
}
