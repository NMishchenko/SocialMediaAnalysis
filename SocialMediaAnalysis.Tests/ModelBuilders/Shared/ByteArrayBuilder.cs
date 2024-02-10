using Bogus;

namespace SocialMediaAnalysis.Tests.ModelBuilders.Shared;

public class ByteArrayBuilder
{
    private readonly Faker _faker;

    public ByteArrayBuilder()
    {
        _faker = new Faker();
    }

    public byte[] Build()
    { 
        return _faker.Random.Bytes(100);
    } 
}