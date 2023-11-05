using MoonhotelsHub.Domain.Model;

namespace MoonhotelsHub.Infrastructure.Apis.HotelLegs
{
    public static class HotelLegsMapperExtensions
    {

        public static HubResponse ToHubResponse(this HotelLegsResponse hotelLegsResponse)
        {
            var hubResponse = new HubResponse();

            foreach (var result in hotelLegsResponse.Results)
            {
                Room room = result.ToRoom();

                var existingRoom = hubResponse.Rooms.FirstOrDefault(r => r.RoomId == room.RoomId);
                if (existingRoom != null)
                    existingRoom.Rates.Add(room.Rates.First());
                else
                    hubResponse.Rooms.Add(room);
            }

            return hubResponse;
        }

        public static HotelLegsRequest ToHotelLegsRequest(this HubRequest hubRequest)
        {
            return new HotelLegsRequest
            {
                Hotel = hubRequest.HotelId,
                CheckInDate = hubRequest.CheckIn,
                NumberOfNights = NightsFromCheckInToCheckOut(hubRequest.CheckIn, hubRequest.CheckOut),
                Guests = hubRequest.NumberOfGuests,
                Rooms = hubRequest.NumberOfRooms,
                Currency = hubRequest.Currency,
            };
        }


        private static Room ToRoom(this HotelLegsResponse.Result result)
        {
            return new Room
            {
                RoomId = result.Room,
                Rates = new List<Rate> { result.ToRate() }
            };
        }

        private static Rate ToRate(this HotelLegsResponse.Result result)
        {
            return new Rate
            {
                MealPlanId = result.Meal,
                IsCancellable = result.CanCancel,
                Price = result.Price
            };
        }

        private static int NightsFromCheckInToCheckOut(DateOnly checkIn, DateOnly checkOut)
        {
            var days = checkIn.DayNumber - checkOut.DayNumber;
            int numberOfDays = Math.Abs(days);
            return numberOfDays;
        }


    }
}