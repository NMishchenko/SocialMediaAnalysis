using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using SocialMediaAnalysis.BLL.Options;
using SocialMediaAnalysis.BLL.Services;
using SocialMediaAnalysis.BLL.Services.Interfaces;
using SocialMediaAnalysis.Tests.Constants;

namespace SocialMediaAnalysis.Tests.UnitTests.RssFeed;

public class RssFeedServiceBaseSetup
{
    protected Mock<INewsApiService> MockNewsApiService = null!;
    protected RssFeedService Sut = null!;
    
    [OneTimeSetUp]
    public void BaseInit()
    {
        MockNewsApiService = new Mock<INewsApiService>();
        var applicationOptions = Options.Create(new ApplicationOptions
        {
            ApiUrl = Uris.NewsApiBaseUri,
            AppUrl = Uris.NewsApiBaseUri
        });

        Sut = new RssFeedService(MockNewsApiService.Object, applicationOptions);
    }
}