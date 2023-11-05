using Microsoft.Extensions.DependencyInjection;
using MoonhotelsHub.Application;
using MoonhotelsHub.Application.Apis;
using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Infrastructure;
using MoonhotelsHub.Infrastructure.Apis.HotelLegs;
using MoonhotelsHub.Infrastructure.Services;

namespace MoonhotelsHub
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMoonHotelsHub(this IServiceCollection services)
        {
            //Podría usarse Reflection para no tener que añadir manualmente futuros IHotelsProviderConnector
            services.AddTransient<IHotelsProviderConnector, HotelLegsConnector>();

            services.AddTransient<IHotelApisProxy, HotelApisProxy>();
            services.AddTransient<IResponseAggregator, ResponseAggregator>();
            services.AddTransient<IHubSystem, HubSystem>();

            services.AddTransient<IBookingEngineConnector, BookingEngineConnector>();
        }
    }
}
