using Azure.AI.TextAnalytics;
using Bogus;
using SocialMediaAnalysis.BLL.Models.Nlp;
using SocialMediaAnalysis.Tests.ModelBuilders.Analysis;

namespace SocialMediaAnalysis.Tests.ModelBuilders.Nlp;

public class SentimentModelBuilder
{
    private readonly Faker<SentimentModel> _faker;

    public SentimentModelBuilder()
    {
        _faker = new Faker<SentimentModel>()
            .RuleFor(x => x.Sentiment, f => f.PickRandom<TextSentiment>())
            .RuleFor(x => x.ConfidenceScore, f => new ConfidenceScoreModelBuilder().Build());
    }

    public SentimentModel Build()
    {
        return _faker.Generate();
    }
}