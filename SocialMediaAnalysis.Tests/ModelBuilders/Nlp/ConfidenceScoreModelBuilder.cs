using Bogus;
using SocialMediaAnalysis.BLL.Models.Nlp;

namespace SocialMediaAnalysis.Tests.ModelBuilders.Nlp;

public class ConfidenceScoreModelBuilder
{
    private readonly Faker<ConfidenceScoreModel> _faker;

    public ConfidenceScoreModelBuilder()
    {
        _faker = new Faker<ConfidenceScoreModel>()
            .RuleFor(x => x.Positive, f => f.Random.Double())
            .RuleFor(x => x.Neutral, f => f.Random.Double())
            .RuleFor(x => x.Negative, f => f.Random.Double());
    }

    public ConfidenceScoreModel Build()
    {
        return _faker.Generate();
    }
}