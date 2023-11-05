using MoonhotelsHub.Domain.Model;

namespace MoonhotelsHub.Application.Apis
{
    public interface IHotelsProviderConnector
    {
        HubResponse Search(HubRequest request);
    }
}