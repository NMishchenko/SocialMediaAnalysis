using Azure.AI.TextAnalytics;

namespace SocialMediaAnalysis.BLL.Models.Nlp;

public class SentimentModel
{
    public TextSentiment Sentiment { get; set; }
    
    public ConfidenceScoreModel ConfidenceScore { get; set; }
}

public class ConfidenceScoreModel
{
    public double Positive { get; set; }
    
    public double Neutral { get; set; }
    
    public double Negative { get; set; }
}