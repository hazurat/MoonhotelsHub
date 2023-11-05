using MoonhotelsHub.Domain.Model;

namespace MoonhotelsHub.Tests.TestData
{
    public static class ObjTestData
    {
        public static HubRequest exampleHubRequestObject
        {
            get => new HubRequest
            {
                HotelId = 1,
                CheckIn = new DateOnly(2018, 10, 20),
                CheckOut = new DateOnly(2018, 10, 25),
                NumberOfGuests = 3,
                NumberOfRooms = 2,
                Currency = "EUR"
            };
        }

        public static HubResponse exampleHubResponseObject
        {
            get => new HubResponse
            {
                Rooms = new List<Room> {
                        new Room {
                            RoomId = 1,
                            Rates = new List<Rate> {
                                new Rate { MealPlanId = 1, IsCancellable = false, Price = 123.48M },
                                new Rate { MealPlanId = 1, IsCancellable = true, Price = 150.00M }
                            }
                        },
                        new Room {
                            RoomId = 2,
                            Rates = new List<Rate> {
                                new Rate { MealPlanId = 1, IsCancellable = false, Price = 148.25M },
                                new Rate { MealPlanId = 2, IsCancellable = false, Price = 165.38M }
                            }
                        }
                    }
            };
        }

    }
}
