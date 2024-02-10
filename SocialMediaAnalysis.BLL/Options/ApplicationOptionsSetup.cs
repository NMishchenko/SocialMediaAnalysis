using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SocialMediaAnalysis.BLL.Options;

public class ApplicationOptionsSetup: IConfigureOptions<ApplicationOptions>
{
    private const string SectionName = ApplicationOptions.SectionName;
    private readonly IConfiguration _configuration;

    public ApplicationOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ApplicationOptions options)
    {
        _configuration
            .GetSection(SectionName)
            .Bind(options);
    }
}