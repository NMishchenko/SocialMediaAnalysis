using Bogus;
using SocialMediaAnalysis.BLL.Models.Analysis;

namespace SocialMediaAnalysis.Tests.ModelBuilders.Analysis;

public class AnalysisInputModelBuilder
{
    private readonly Faker<AnalysisInputModel> _faker;
    private static readonly string[] ValidDomains = {
        "https://www.bbc.com/news/uk-england-shropshire-67785102",
        "https://www.bbc.com/news/uk-england-northamptonshire-67812697",
        "https://www.bbc.com/news/articles/c28yr2g4lpjo"
    };

    public AnalysisInputModelBuilder()
    {
        _faker = new Faker<AnalysisInputModel>()
            .RuleFor(x => x.PageUrl, f => f.PickRandom(ValidDomains));
    }

    public AnalysisInputModel Build()
    {
        return _faker.Generate();
    }
}