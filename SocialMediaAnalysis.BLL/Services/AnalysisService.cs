using SmartReader;
using SocialMediaAnalysis.BLL.Exceptions;
using SocialMediaAnalysis.BLL.Models.Analysis;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.BLL.Services;

public class AnalysisService : IAnalysisService
{
    private readonly INlpService _nlpService;
    public AnalysisService(INlpService nlpService)
    {
        _nlpService = nlpService;
    }
    
    public async Task<AnalysisOutputModel> GetAnalysisAsync(AnalysisInputModel analysisInputModel)
    {
        var article = await Reader.ParseArticleAsync(analysisInputModel.PageUrl);

        if (!article.IsReadable)
        {
            throw new BadRequestException();
        }

        var sentiment = await _nlpService.AnalyzeSentimentAsync(article.TextContent);
        var keyPhrases = await _nlpService.GetKeyPhrasesAsync(article.TextContent);

        return new AnalysisOutputModel() { Sentiment = sentiment, KeyPhrases = keyPhrases.Take(10) };
    }
}
