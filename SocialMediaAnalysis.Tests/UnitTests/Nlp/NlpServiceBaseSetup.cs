using Azure;
using Azure.AI.TextAnalytics;
using Moq;
using NUnit.Framework;
using SocialMediaAnalysis.BLL.Services;

namespace SocialMediaAnalysis.Tests.UnitTests.Nlp;

public class NlpServiceBaseSetup
{
    protected Mock<TextAnalyticsClient> MockTextAnalyticsClient = null!;
    protected Mock<Response> MockResponse = null!;
    protected NlpService Sut = null!;
    
    [OneTimeSetUp]
    public void BaseInit()
    {
        MockTextAnalyticsClient = new Mock<TextAnalyticsClient>();
        MockResponse = new Mock<Response>();

        Sut = new NlpService(MockTextAnalyticsClient.Object);
    }
}