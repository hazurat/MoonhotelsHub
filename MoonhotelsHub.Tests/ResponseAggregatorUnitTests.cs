using FluentAssertions;
using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Domain.Model;
using MoonhotelsHub.Infrastructure.Services;
using MoonhotelsHub.Tests.TestData;
using Xunit;

namespace MoonhotelsHub.Tests
{
    public class ResponseAggregatorUnitTests
    {

        [Fact]
        public void Returns_AllRoomRates_ForOneApi()
        {
            //Arrange
            IResponseAggregator responseAggregator = new ResponseAggregator();
            HubResponse aggregateResponse = new HubResponse();
            List<HubResponse> apiResponseList = new List<HubResponse>
            {
                ObjTestData.exampleHubResponseObject
            };

            //Act
            var sut = responseAggregator.Aggregate(aggregateResponse, apiResponseList);

            //Assert
            sut.Should().BeEquivalentTo(aggregateResponse);
        }

        [Fact]
        public void Returns_TwiceAllRoomRates_ForTwoApis()
        {
            //Arrange
            IResponseAggregator responseAggregator = new ResponseAggregator();
            HubResponse aggregateResponse = new HubResponse();
            List<HubResponse> apiResponseList = new List<HubResponse>
            {
                ObjTestData.exampleHubResponseObject,
                ObjTestData.exampleHubResponseObject,
            };

            //Act
            var sut = responseAggregator.Aggregate(aggregateResponse, apiResponseList);

            //Assert
            sut.Should().BeEquivalentTo(aggregateResponse);
        }

    }
}
