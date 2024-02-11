using Bogus;

namespace SocialMediaAnalysis.Tests.ModelBuilders.Shared;

public class TextBuilder
{
    private readonly Faker _faker;

    public TextBuilder()
    {
        _faker = new Faker();
    }

    public string Build()
    {
        return _faker.Lorem.Text();
    }

    public IEnumerable<string> Build(int count)
    {
        for (var i = 0; i < count; i++)
        {
            yield return _faker.Lorem.Text();
        }
    }
}