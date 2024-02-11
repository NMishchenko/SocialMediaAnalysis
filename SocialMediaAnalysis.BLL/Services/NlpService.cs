using Azure.AI.TextAnalytics;
using SocialMediaAnalysis.BLL.Models.Nlp;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.BLL.Services;

public class NlpService : INlpService
{
    private readonly TextAnalyticsClient _textAnalyticsClient;
    private const int CharactersLimit = 5120;

    public NlpService(TextAnalyticsClient textAnalyticsClient)
    {
        _textAnalyticsClient = textAnalyticsClient;
    }
    
    public async Task<IEnumerable<string>> GetKeyPhrasesAsync(string text)
    {
        if (text.Length > CharactersLimit)
        {
            text = text[..CharactersLimit];
        }
        
        return (await _textAnalyticsClient.ExtractKeyPhrasesAsync(text))
            .Value
            .Select(v => v);
    }
    
    public async Task<SentimentModel> AnalyzeSentimentAsync(string text)
    {
        if (text.Length > CharactersLimit)
        {
            text = text[..CharactersLimit];
        }
        
        var result = (await _textAnalyticsClient.AnalyzeSentimentAsync(text)).Value;

        return new SentimentModel()
        {
            Sentiment = result.Sentiment,
            ConfidenceScore = new ConfidenceScoreModel()
            {
                Negative = result.ConfidenceScores.Negative,
                Positive = result.ConfidenceScores.Positive,
                Neutral = result.ConfidenceScores.Neutral
            }
        };
    }
}