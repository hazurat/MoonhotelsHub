using FluentAssertions;
using MoonhotelsHub.Application.Apis.HotelLegs;
using MoonhotelsHub.Infrastructure.Apis.HotelLegs;
using MoonhotelsHub.Tests.TestData;
using NSubstitute;
using Xunit;

namespace MoonhotelsHub.Tests
{
    public class HotelLegsConnectorUnitTests
    {
        private readonly IHotelLegsApi _iHotelLegsApi;

        public HotelLegsConnectorUnitTests()
        {
            _iHotelLegsApi = Substitute.For<IHotelLegsApi>();
            _iHotelLegsApi
                .Search(JsonTestData.hotelLegsRequestJson)
                .Returns(JsonTestData.hotelLegsResponseJson);
        }

        [Fact]
        public void HotelLegsConnector_Returns_HubResponse_WhenValidRequest()
        {
            //Arrange
            HotelLegsConnector hotelLegsConnector = new(_iHotelLegsApi);

            //Act
            var sut = hotelLegsConnector.Search(ObjTestData.exampleHubRequestObject);

            //Assert
            sut.Should().BeEquivalentTo(ObjTestData.exampleHubResponseObject);
        }

    }
}

