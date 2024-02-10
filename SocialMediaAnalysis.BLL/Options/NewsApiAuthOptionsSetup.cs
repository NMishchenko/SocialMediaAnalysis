using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SocialMediaAnalysis.BLL.Options;

public class NewsApiAuthOptionsSetup: IConfigureOptions<NewsApiAuthOptions>
{
    private const string SectionName = NewsApiAuthOptions.SectionName;
    private readonly IConfiguration _configuration;

    public NewsApiAuthOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(NewsApiAuthOptions options)
    {
        _configuration
            .GetSection(SectionName)
            .Bind(options);
    }
}