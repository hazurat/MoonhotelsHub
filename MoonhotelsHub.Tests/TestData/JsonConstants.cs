namespace MoonhotelsHub.Tests.TestData
{
    public static class JsonTestData
    {
        public const string hubSystemRequestJson =
            """    
            {
              "hotelId": 1,
              "checkIn": "2018-10-20",
              "checkOut": "2018-10-25",
              "numberOfGuests": 3,
              "numberOfRooms": 2,
              "currency": "EUR"
            }
            """;
        public const string hubSystemResponseJson =
            """
            {
              "rooms": [
                {
                  "roomId": 1,
                  "rates": [
                    {
                      "mealPlanId": 1,
                      "isCancellable": false,
                      "price": 123.48
                    },
                    {
                      "mealPlanId": 1,
                      "isCancellable": true,
                      "price": 150.00
                    }
                  ]
                },
                {
                  "roomId": 2,
                  "rates": [
                    {
                      "mealPlanId": 1,
                      "isCancellable": false,
                      "price": 148.25
                    },
                    {
                      "mealPlanId": 2,
                      "isCancellable": false,
                      "price": 165.38
                    }
                  ]
                }
              ]
            }
            """;

        public const string hotelLegsRequestJson =
            """
            {
              "hotel": 1,
              "checkInDate": "2018-10-20",
              "numberOfNights": 5,
              "guests": 3,
              "rooms": 2,
              "currency": "EUR"
            }
            """;
        public const string hotelLegsResponseJson =
            """
            {
              "results": [
                {
                  "room": 1,
                  "meal": 1,
                  "canCancel": false,
                  "price": 123.48
                },
                {
                  "room": 1,
                  "meal": 1,
                  "canCancel": true,
                  "price": 150.00
                },
                {
                  "room": 2,
                  "meal": 1,
                  "canCancel": false,
                  "price": 148.25
                },
                {
                  "room": 2,
                  "meal": 2,
                  "canCancel": false,
                  "price": 165.38
                }
              ]
            }
            """;


    }
}
