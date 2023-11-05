using MoonhotelsHub.Domain.Model;

namespace MoonhotelsHub.Application.Services
{
    public interface IHotelApisProxy
    {
        List<HubResponse> Search(HubRequest request);
    }

}
