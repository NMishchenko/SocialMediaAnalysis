using SocialMediaAnalysis.BLL.Models.Analysis;

namespace SocialMediaAnalysis.BLL.Services.Interfaces;

public interface IAnalysisService
{
    Task<AnalysisOutputModel> GetAnalysisAsync(AnalysisInputModel analysisInputModel);
}
