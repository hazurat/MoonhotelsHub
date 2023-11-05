using MoonhotelsHub.Domain.Model;

namespace MoonhotelsHub.Application.Services
{
    public interface IResponseAggregator
    {
        HubResponse Aggregate(HubResponse hubResponse, List<HubResponse> apiResponses);
    }
}