using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Domain.Model;
using System.Text.Json;

namespace MoonhotelsHub.Infrastructure.Services
{

    public class HubSystem : IHubSystem
    {
        private readonly IHotelApisProxy _hotelApisProxy;
        private readonly IResponseAggregator _responseAggregator;


        public HubSystem(
            IHotelApisProxy hotelApisProxy,
            IResponseAggregator responseAggregator
            )
        {
            _hotelApisProxy = hotelApisProxy;
            _responseAggregator = responseAggregator;
        }

        public HubResponse Search(HubRequest request)
        {
            var hubResponse = new HubResponse();
            //Send the request to the Hotel Provider Proxy
            var apiResponses = _hotelApisProxy.Search(request);
            //Aggregate the response 
            var aggregatedResponse = _responseAggregator.Aggregate(hubResponse, apiResponses);
            return aggregatedResponse;
        }


    }
}
