using NUnit.Framework;
using RichardSzalay.MockHttp;
using SocialMediaAnalysis.BLL.Services;

namespace SocialMediaAnalysis.Tests.UnitTests.NewsApi;

public class NewsApiServiceBaseSetup
{
    protected MockHttpMessageHandler MockHttpMessageHandler = null!;
    protected NewsApiService Sut = null!;
    
    [OneTimeSetUp]
    public void BaseInit()
    {
        MockHttpMessageHandler = new MockHttpMessageHandler();

        Sut = new NewsApiService(new HttpClient(MockHttpMessageHandler));
    }
}