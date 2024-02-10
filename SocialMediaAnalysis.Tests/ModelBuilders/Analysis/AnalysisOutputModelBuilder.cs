using Bogus;
using SocialMediaAnalysis.BLL.Models.Analysis;
using SocialMediaAnalysis.Tests.ModelBuilders.Nlp;

namespace SocialMediaAnalysis.Tests.ModelBuilders.Analysis;

public class AnalysisOutputModelBuilder
{
    private readonly Faker<AnalysisOutputModel> _faker;

    public AnalysisOutputModelBuilder()
    {
        _faker = new Faker<AnalysisOutputModel>()
            .RuleFor(x => x.Sentiment, f => new SentimentModelBuilder().Build())
            .RuleFor(x => x.KeyPhrases, f => f.Lorem.Words(f.Random.Number(1, 10)));
    }

    public AnalysisOutputModel Build()
    {
        return _faker.Generate();
    }
}