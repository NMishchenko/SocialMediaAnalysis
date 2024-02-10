using Bogus;
using SocialMediaAnalysis.BLL.Models.News;

namespace SocialMediaAnalysis.Tests.ModelBuilders.News;

public class ApiResponseModelBuilder
{
    private readonly Faker<ApiResponseModel> _faker;
    
    public ApiResponseModelBuilder()
    {
        _faker = new Faker<ApiResponseModel>()
            .RuleFor(x => x.Articles, f => ArticleModelBuilder.BuildList(f.Random.Number(1, 10)))
            .RuleFor(x => x.TotalResults, (_, m) => m.Articles.Count);
    }

    public ApiResponseModel Build()
    {
        return _faker
            .Generate();
    }
    
    private static class ArticleModelBuilder
    {
        public static List<ArticleModel> BuildList(int count)
        {
            var faker = new Faker();

            var articles = new List<ArticleModel>();
            for (var i = 0; i < count; i++)
            {
                var article = new ArticleModel
                {
                    Source = new SourceModel
                    {
                        Id = faker.Random.Guid().ToString(),
                        Name = faker.Company.CompanyName(),
                        Description = faker.Company.CatchPhrase(),
                        Url = faker.Internet.Url(),
                        Category = faker.Commerce.Categories(1)[0],
                        Language = faker.Random.Word(),
                        Country = faker.Address.Country()
                    },
                    Author = faker.Name.FullName(),
                    Title = faker.Lorem.Sentence(),
                    Description = faker.Lorem.Paragraph(),
                    Url = faker.Internet.Url(),
                    UrlToImage = faker.Image.PicsumUrl(),
                    PublishedAt = faker.Date.Recent(),
                    Content = faker.Lorem.Paragraphs()
                };
                articles.Add(article);
            }

            return articles;
        }
    }
}