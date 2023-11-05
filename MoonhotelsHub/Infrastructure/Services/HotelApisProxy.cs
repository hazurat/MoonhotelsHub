using MoonhotelsHub.Application.Apis;
using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Domain.Model;

namespace MoonhotelsHub.Infrastructure.Services
{
    public class HotelApisProxy : IHotelApisProxy
    {
        private readonly IEnumerable<IHotelsProviderConnector> _hotelsApis;

        public HotelApisProxy(IEnumerable<IHotelsProviderConnector> hotelsApis)
        {
            _hotelsApis = hotelsApis;
        }

        public List<HubResponse> Search(HubRequest request)
        {
            var listOfApiResponses = new List<HubResponse>();
            foreach (var hotelsApi in _hotelsApis)
            {
                var res = hotelsApi.Search(request);
                listOfApiResponses.Add(res);
            }
            return listOfApiResponses;
        }


    }
}
