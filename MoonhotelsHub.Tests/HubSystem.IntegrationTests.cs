using FluentAssertions;
using MoonhotelsHub.Application.Apis;
using MoonhotelsHub.Application.Apis.HotelLegs;
using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Infrastructure.Apis.HotelLegs;
using MoonhotelsHub.Infrastructure.Services;
using MoonhotelsHub.Tests.TestData;
using NSubstitute;
using Xunit;

namespace MoonhotelsHub.Tests
{
    public class HubSystemIntegrationTests
    {
        private readonly IHotelsProviderConnector _hotelsProviderConnector;
        private readonly IHotelApisProxy _hotelApisProxy;
        private readonly IResponseAggregator _responseAggregator;

        public HubSystemIntegrationTests()
        {
            IHotelLegsApi __ihotelLegsApi = Substitute.For<IHotelLegsApi>();
            __ihotelLegsApi
                .Search(JsonTestData.hotelLegsRequestJson)
                .Returns(JsonTestData.hotelLegsResponseJson);

            _hotelsProviderConnector = new HotelLegsConnector(__ihotelLegsApi);
            _hotelApisProxy = new HotelApisProxy(new List<IHotelsProviderConnector> { _hotelsProviderConnector });
            _responseAggregator = new ResponseAggregator();
        }

        [Fact]
        public void HubRequest_Returns_HubResponse()
        {
            //Arrange            
            IHubSystem moonHotelsHub = new HubSystem(_hotelApisProxy, _responseAggregator);

            //Act
            var sut = moonHotelsHub.Search(ObjTestData.exampleHubRequestObject);

            //Assert
            sut.Should().BeEquivalentTo(ObjTestData.exampleHubResponseObject);
        }

    }
}
