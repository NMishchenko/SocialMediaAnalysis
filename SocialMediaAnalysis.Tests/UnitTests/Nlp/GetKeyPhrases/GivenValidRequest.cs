using Azure;
using Azure.AI.TextAnalytics;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SocialMediaAnalysis.Tests.ModelBuilders.Shared;

namespace SocialMediaAnalysis.Tests.UnitTests.Nlp.GetKeyPhrases;

[TestFixture]
public class GivenValidRequest: NlpServiceBaseSetup
{
    private readonly IEnumerable<string> _expected = new TextBuilder().Build(10);
    private readonly string _text = new TextBuilder().Build();
    private Response<KeyPhraseCollection> _response = null!;
    private IEnumerable<string> _actual = null!;
    
    [OneTimeSetUp]
    public async Task Init()
    {
        _response = Response.FromValue(TextAnalyticsModelFactory.KeyPhraseCollection(_expected.ToList()), MockResponse.Object);

        MockTextAnalyticsClient
            .Setup(x => x.ExtractKeyPhrasesAsync(_text, default, default))
            .ReturnsAsync(_response);
        
        _actual = await Sut.GetKeyPhrasesAsync(_text);
    }
    
    [Test]
    public void ThenTextAnalyticsClientExtractKeyPhrasesAsyncIsCalledOnce()
    {
        MockTextAnalyticsClient
            .Verify(x => x.ExtractKeyPhrasesAsync(_text, default, default), Times.Once);
    }
    
    [Test]
    public void ThenActualEqualsExpected()
    {
        _actual
            .Should()
            .BeEquivalentTo(_response.Value);
    }
}