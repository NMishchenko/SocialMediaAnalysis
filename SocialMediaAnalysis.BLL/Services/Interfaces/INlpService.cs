using SocialMediaAnalysis.BLL.Models.Nlp;

namespace SocialMediaAnalysis.BLL.Services.Interfaces;

public interface INlpService
{
    Task<IEnumerable<string>> GetKeyPhrasesAsync(string text);

    Task<SentimentModel> AnalyzeSentimentAsync(string text);
}