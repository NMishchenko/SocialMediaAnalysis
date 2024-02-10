using FluentAssertions;
using Moq;
using NUnit.Framework;
using SocialMediaAnalysis.BLL.Models.Analysis;
using SocialMediaAnalysis.Tests.ModelBuilders.Analysis;

namespace SocialMediaAnalysis.Tests.UnitTests.Analysis.GetAnalysis;

[TestFixture]
public class GivenValidRequest: AnalysisServiceBaseSetup
{
    private AnalysisOutputModel _expected = null!;
    private AnalysisInputModel _request = null!;
    private AnalysisOutputModel _actual = null!;
    
    [OneTimeSetUp]
    public async Task Init()
    {
        _expected = new AnalysisOutputModelBuilder().Build();
        _request = new AnalysisInputModelBuilder().Build();

        MockNlpService
            .Setup(x => x.AnalyzeSentimentAsync(It.IsAny<string>()))
            .ReturnsAsync(_expected.Sentiment);

        MockNlpService
            .Setup(x => x.GetKeyPhrasesAsync(It.IsAny<string>()))
            .ReturnsAsync(_expected.KeyPhrases);

        _actual = await Sut.GetAnalysisAsync(_request);
    }

    [Test]
    public void ThenNlpServiceAnalyzeSentimentAsyncIsCalledOnce()
    {
        MockNlpService
            .Verify(x => x.AnalyzeSentimentAsync(It.IsAny<string>()), Times.Once());
    }
    
    [Test]
    public void ThenNlpServiceGetKeyPhrasesAsyncIsCalledOnce()
    {
        MockNlpService
            .Verify(x => x.GetKeyPhrasesAsync(It.IsAny<string>()), Times.Once());
    }
    
    [Test]
    public void ThenActualEqualsExpected()
    {
        _actual
            .Should()
            .BeEquivalentTo(_expected);
    }
}