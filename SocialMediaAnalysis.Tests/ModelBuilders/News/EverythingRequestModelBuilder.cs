using Bogus;
using SocialMediaAnalysis.BLL.Enums;
using SocialMediaAnalysis.BLL.Models.News;

namespace SocialMediaAnalysis.Tests.ModelBuilders.News;

public class EverythingRequestModelBuilder
{
    private readonly Faker<EverythingRequestModel> _faker;

    public EverythingRequestModelBuilder()
    {
        _faker = new Faker<EverythingRequestModel>()
            .RuleFor(x => x.Q, f => f.Lorem.Word())
            .RuleFor(x => x.SearchIn, f => new List<string> { f.Lorem.Word(), f.Lorem.Word() })
            .RuleFor(x => x.Sources, f => new List<string> { f.Lorem.Word(), f.Lorem.Word() })
            .RuleFor(x => x.Domains, f => new List<string> { f.Internet.DomainName(), f.Internet.DomainName() })
            .RuleFor(x => x.ExcludeDomains, f => new List<string> { f.Internet.DomainName(), f.Internet.DomainName() })
            .RuleFor(x => x.From, f => f.Date.Past())
            .RuleFor(x => x.To, f => f.Date.Future())
            .RuleFor(x => x.Language, f => f.PickRandom<Language>())
            .RuleFor(x => x.SortBy, f => f.PickRandom<SortBy>())
            .RuleFor(x => x.PageSize, f => f.Random.Int(1, 100))
            .RuleFor(x => x.Page, f => f.Random.Int(1, 10));
    }

    public EverythingRequestModel Build()
    {
        return _faker
            .Generate();
    }
}