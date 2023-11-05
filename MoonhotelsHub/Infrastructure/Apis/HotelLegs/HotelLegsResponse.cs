
namespace MoonhotelsHub.Infrastructure.Apis.HotelLegs
{

    public class HotelLegsResponse
    {
        public List<Result> Results { get; set; } = new List<Result>();

        public class Result
        {
            public int Room { get; set; }
            public int Meal { get; set; }
            public bool CanCancel { get; set; }
            public decimal Price { get; set; }
        }
    }


}
