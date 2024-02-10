using Azure;
using Azure.AI.TextAnalytics;
using Moq;
using NUnit.Framework;
using SocialMediaAnalysis.BLL.Models.Nlp;
using SocialMediaAnalysis.Tests.ModelBuilders.Shared;

namespace SocialMediaAnalysis.Tests.UnitTests.Nlp.AnalyzeSentiment;

[TestFixture]
public class GivenValidRequest: NlpServiceBaseSetup
{
    private readonly string _document = new TextBuilder().Build();
    private Response<DocumentSentiment> _response = null!;
    private SentimentModel _actual = null!;
    
    [OneTimeSetUp]
    public async Task Init()
    {
        _response = Response.FromValue(TextAnalyticsModelFactory.DocumentSentiment(
            TextSentiment.Mixed, It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(),
            new List<SentenceSentiment>()), MockResponse.Object);

        MockTextAnalyticsClient
            .Setup(x => x.AnalyzeSentimentAsync(It.IsAny<string>(), default, default))
            .ReturnsAsync(_response);

        _actual = await Sut.AnalyzeSentimentAsync(_document);
    }
    
    /*[Test]
    public void ThenTextAnalyticsClientAnalyzeSentimentAsyncIsCalledOnce()
    {
        MockTextAnalyticsClient
            .Verify(x => x.AnalyzeSentimentAsync(It.IsAny<string>(), default, default), Times.Once);
    }
    
    [Test]
    public void ThenActualIsValid()
    {
        _actual
            .Should()
            .NotBeNull();
    }*/
}