using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using SocialMediaAnalysis.BLL.Models.News;
using SocialMediaAnalysis.Tests.Constants;
using SocialMediaAnalysis.Tests.ModelBuilders.News;

namespace SocialMediaAnalysis.Tests.UnitTests.NewsApi.GetEverythingTests;

[TestFixture]
public class GivenValidRequest: NewsApiServiceBaseSetup
{
    private ApiResponseModel _expected = null!;
    private ApiResponseModel _actual = null!;
    private EverythingRequestModel _request = null!;
    private MockedRequest _mockedRequest = null!;
    
    [OneTimeSetUp]
    public async Task Init()
    {
        _expected = new ApiResponseModelBuilder().Build();
        _request = new EverythingRequestModelBuilder().Build();
        
        _mockedRequest = MockHttpMessageHandler
            .When(Uris.NewsApiBaseUri)
            .Respond("application/json", JsonConvert.SerializeObject(_expected));

        _actual = await Sut.GetEverythingAsync(_request);
    }

    [Test]
    public void ThenHttpClientIsCalledOnce()
    {
        MockHttpMessageHandler.GetMatchCount(_mockedRequest).Should().Be(1);
    }
    
    [Test]
    public void ThenActualEqualsExpected()
    {
        _actual
            .Should()
            .BeEquivalentTo(_expected, opt => opt.Excluding(x => x.ChartData));
    }
}