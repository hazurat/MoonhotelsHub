using MoonhotelsHub.Application.Apis;
using MoonhotelsHub.Application.Apis.HotelLegs;
using MoonhotelsHub.Domain.Model;
using System.Text.Json;

namespace MoonhotelsHub.Infrastructure.Apis.HotelLegs
{
    public class HotelLegsConnector : IHotelsProviderConnector
    {
        private readonly IHotelLegsApi _hotelLegsApi;
        private readonly JsonSerializerOptions options;

        public HotelLegsConnector(IHotelLegsApi hotelLegsApi)
        {
            _hotelLegsApi = hotelLegsApi;
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };
        }

        public HubResponse Search(HubRequest request)
        {
            var hotelLegsRequest = request.ToHotelLegsRequest();
            var hotelLegsJsonRequest = JsonSerializer.Serialize(hotelLegsRequest, options);

            var hotelLegsJsonResponse = _hotelLegsApi.Search(hotelLegsJsonRequest);

            var hotelLegsResponse = JsonSerializer.Deserialize<HotelLegsResponse>(hotelLegsJsonResponse, options);
            var response = hotelLegsResponse!.ToHubResponse();
            return response;
        }

    }
}
