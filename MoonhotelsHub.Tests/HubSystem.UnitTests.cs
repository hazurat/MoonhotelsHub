using FluentAssertions;
using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Domain.Model;
using MoonhotelsHub.Infrastructure.Services;
using MoonhotelsHub.Tests.TestData;
using NSubstitute;
using Xunit;

namespace MoonhotelsHub.Tests
{
    public class HubSystemUnitTests
    {
        private readonly IHotelApisProxy _hotelsApisProxy;
        private readonly IResponseAggregator _responseAgregator;

        public HubSystemUnitTests()
        {
            _hotelsApisProxy = Substitute.For<IHotelApisProxy>();
            _hotelsApisProxy
                .Search(Arg.Is<HubRequest>(x => x.HotelId == 1))
                .Returns(new List<HubResponse> { ObjTestData.exampleHubResponseObject });
            _responseAgregator = Substitute.For<IResponseAggregator>();
            _responseAgregator
                .Aggregate(Arg.Any<HubResponse>(), Arg.Any<List<HubResponse>>())
                .Returns(ObjTestData.exampleHubResponseObject);

        }

        [Fact]
        public void HubRequest_Returns_HubResponse()
        {
            //Arrange            
            HubSystem moonHotelsHub = new(_hotelsApisProxy, _responseAgregator);

            //Act
            var sut = moonHotelsHub.Search(ObjTestData.exampleHubRequestObject);

            //Assert
            sut.Should().BeEquivalentTo(ObjTestData.exampleHubResponseObject);
        }



    }
}