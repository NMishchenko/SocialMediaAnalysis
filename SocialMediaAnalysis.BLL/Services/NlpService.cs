using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Configuration;
using SocialMediaAnalysis.BLL.Models.Nlp;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.BLL.Services;

public class NlpService : INlpService
{
    private readonly TextAnalyticsClient _textAnalyticsClient;

    public NlpService(IConfiguration configuration)
    {
        var azureKey = configuration.GetSection("AzureKey").Value;
        var azureEndpoint = configuration.GetSection("AzureEndpoint").Value;
        
        ArgumentNullException.ThrowIfNull(azureKey);
        ArgumentNullException.ThrowIfNull(azureEndpoint);
        
        AzureKeyCredential credentials = new(azureKey);
        Uri endpoint = new(azureEndpoint);
        _textAnalyticsClient = new TextAnalyticsClient(endpoint, credentials);
    }
    
    public async Task<IEnumerable<string>> GetKeyPhrasesAsync(string text)
    {
        if (text.Length > 125000)
        {
            text = text[..125000];
        }
        
        return (await _textAnalyticsClient.ExtractKeyPhrasesAsync(text))
            .Value
            .Select(v => v);
    }
    
    public async Task<SentimentModel> AnalyzeSentimentAsync(string text)
    {
        if (text.Length > 125000)
        {
            text = text[..125000];
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