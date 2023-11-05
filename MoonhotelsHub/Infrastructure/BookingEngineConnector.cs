using MoonhotelsHub.Application;
using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Domain.Model;
using System.Text.Json;

namespace MoonhotelsHub.Infrastructure
{
    public class BookingEngineConnector : IBookingEngineConnector
    {
        private readonly JsonSerializerOptions options;
        private readonly IHubSystem _hubSystem;

        public BookingEngineConnector(IHubSystem hubSystem)
        {
            _hubSystem = hubSystem;
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public string Search(string jsonRequest)
        {
            var request = JsonSerializer.Deserialize<HubRequest>(jsonRequest, options)!;
            var response = _hubSystem.Search(request);
            return JsonSerializer.Serialize(response, options);
        }


    }
}
