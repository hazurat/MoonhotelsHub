using MoonhotelsHub.Domain.Model;

namespace MoonhotelsHub.Application.Services
{
    public interface IHubSystem
    {
        public HubResponse Search(HubRequest request);

    }
}
