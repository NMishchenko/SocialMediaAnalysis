using FluentAssertions;
using Moq;
using NUnit.Framework;
using SocialMediaAnalysis.BLL.Exceptions;
using SocialMediaAnalysis.BLL.Models.Analysis;
using SocialMediaAnalysis.Tests.ModelBuilders.Analysis;

namespace SocialMediaAnalysis.Tests.UnitTests.Analysis.GetAnalysis;

[TestFixture]
public class GiveNonReadableArticle: AnalysisServiceBaseSetup
{
    private AnalysisOutputModel _expected = null!;
    private AnalysisInputModel _request = null!;
    private Exception _exception = null!;
    
    [OneTimeSetUp]
    public async Task Init()
    {
        _expected = new AnalysisOutputModelBuilder().Build();
        _request = new AnalysisInputModel
        {
            PageUrl = "https://bbc.com"
        };

        MockNlpService
            .Setup(x => x.AnalyzeSentimentAsync(It.IsAny<string>()))
            .ReturnsAsync(_expected.Sentiment);

        MockNlpService
            .Setup(x => x.GetKeyPhrasesAsync(It.IsAny<string>()))
            .ReturnsAsync(_expected.KeyPhrases);

        try
        {
            _ = await Sut.GetAnalysisAsync(_request);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Test]
    public void ThenBadRequestExceptionIsThrown()
    {
        _exception.Should().BeOfType<BadRequestException>();
    }
}