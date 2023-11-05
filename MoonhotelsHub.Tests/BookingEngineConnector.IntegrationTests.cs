using FluentAssertions;
using MoonhotelsHub.Application;
using MoonhotelsHub.Application.Apis;
using MoonhotelsHub.Application.Apis.HotelLegs;
using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Infrastructure;
using MoonhotelsHub.Infrastructure.Apis.HotelLegs;
using MoonhotelsHub.Infrastructure.Services;
using MoonhotelsHub.Tests.TestData;
using NSubstitute;
using Xunit;

namespace MoonhotelsHub.Tests
{
    public class BookingEngineConnectorIntegrationTests
    {
        private readonly IHubSystem _hubSystem;
        private readonly IHotelApisProxy _hotelApisProxy;
        private readonly IHotelsProviderConnector _hotelsProviderConnector;
        private readonly IResponseAggregator _responseAggregator;

        public BookingEngineConnectorIntegrationTests()
        {
            IHotelLegsApi __ihotelLegsApi = Substitute.For<IHotelLegsApi>();
            __ihotelLegsApi
                .Search(JsonTestData.hotelLegsRequestJson)
                .Returns(JsonTestData.hotelLegsResponseJson);

            _hotelsProviderConnector = new HotelLegsConnector(__ihotelLegsApi);
            _hotelApisProxy = new HotelApisProxy(new List<IHotelsProviderConnector> { _hotelsProviderConnector });
            _responseAggregator = new ResponseAggregator();
            _hubSystem = new HubSystem(_hotelApisProxy, _responseAggregator);
        }

        [Fact]
        public void JsonHubRequest_Returns_JsonHubResponse()
        {
            //Arrange
            IBookingEngineConnector bookingEngineConnector = new BookingEngineConnector(_hubSystem);

            //Act
            var sut = bookingEngineConnector.Search(JsonTestData.hubSystemRequestJson);

            //Assert
            sut.Should().BeEquivalentTo(JsonTestData.hubSystemResponseJson);
        }

    }
}
