using FluentAssertions;
using Moq;
using NUnit.Framework;
using SocialMediaAnalysis.BLL.Models.News;
using SocialMediaAnalysis.Tests.ModelBuilders.News;

namespace SocialMediaAnalysis.Tests.UnitTests.RssFeed.GetNewsRssFeed;

[TestFixture]
public class GivenValidRequest: RssFeedServiceBaseSetup
{
    private ApiResponseModel _apiResponseModel = null!;
    private EverythingRequestModel _request = null!;
    private byte[] _actual = null!;
    
    [OneTimeSetUp]
    public async Task Init()
    {
        _apiResponseModel = new ApiResponseModelBuilder().Build();
        _request = new EverythingRequestModelBuilder().Build();
        
        MockNewsApiService
            .Setup(x => x.GetEverythingAsync(_request))
            .ReturnsAsync(_apiResponseModel);
        
        _actual = await Sut.GetNewsRssFeedAsync(_request);
    }

    [Test]
    public void ThenNewsApiServiceGetEverythingAsyncIsCalledOnce()
    {
        MockNewsApiService
            .Verify(x => x.GetEverythingAsync(_request), Times.Once);
    }
    
    [Test]
    public void ThenActualIsValid()
    {
        _actual
            .Should()
            .NotBeNullOrEmpty();
    }
}