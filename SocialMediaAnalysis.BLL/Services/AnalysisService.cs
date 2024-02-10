using SmartReader;
using SocialMediaAnalysis.BLL.Exceptions;
using SocialMediaAnalysis.BLL.Models.Analysis;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.BLL.Services;

public class AnalysisService : IAnalysisService
{
    public async Task<AnalysisOutputModel> GetAnalysisAsync(AnalysisInputModel analysisInputModel)
    {
        Article article = Reader.ParseArticle(analysisInputModel.PageUrl);

        if (!article.IsReadable)
        {
            throw new BadRequestException();
        }

        // TODO: Call azure service to process article.

        return new AnalysisOutputModel() { Content = article.TextContent };
    }
}
