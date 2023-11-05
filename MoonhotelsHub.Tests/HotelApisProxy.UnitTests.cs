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
    public class HotelApisProxyUnitTests
    {
        private readonly IEnumerable<IHotelsProviderConnector> _1hotelProviderConnectors;
        private readonly IEnumerable<IHotelsProviderConnector> _2hotelProviderConnectors;
        public HotelApisProxyUnitTests()
        {
            IHotelLegsApi _iHotelLegsApi = Substitute.For<IHotelLegsApi>();
            _iHotelLegsApi
                .Search(JsonTestData.hotelLegsRequestJson)
                .Returns(JsonTestData.hotelLegsResponseJson);

            _1hotelProviderConnectors = new List<IHotelsProviderConnector>
            {
                new HotelLegsConnector(_iHotelLegsApi),
            };
            _2hotelProviderConnectors = new List<IHotelsProviderConnector>
            {
                new HotelLegsConnector(_iHotelLegsApi),
                new HotelLegsConnector(_iHotelLegsApi),
            };
        }

        [Fact]
        public void Returns_When_1_Apis()
        {
            //Arrange            
            IHotelApisProxy hotelApisProxy = new HotelApisProxy(_1hotelProviderConnectors);

            //Act
            var sut = hotelApisProxy.Search(ObjTestData.exampleHubRequestObject);

            //Assert
            sut.Should().HaveCount(1);
        }

        [Fact]
        public void Returns_When_2_Apis()
        {
            //Arrange            
            IHotelApisProxy hotelApisProxy = new HotelApisProxy(_2hotelProviderConnectors);

            //Act
            var sut = hotelApisProxy.Search(ObjTestData.exampleHubRequestObject);

            //Assert
            sut.Should().HaveCount(2);
        }


    }
}
