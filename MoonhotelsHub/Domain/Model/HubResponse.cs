namespace MoonhotelsHub.Domain.Model
{
    public class HubResponse
    {
        public List<Room> Rooms { get; set; } = new List<Room>();
    }

    public class Room
    {
        public int RoomId { get; set; }
        public List<Rate> Rates { get; set; } = new List<Rate>();
    }

    public class Rate
    {
        public int MealPlanId { get; set; }
        public bool IsCancellable { get; set; }
        public decimal Price { get; set; }
    }

}