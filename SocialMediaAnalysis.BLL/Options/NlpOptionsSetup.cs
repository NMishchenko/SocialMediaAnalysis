using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SocialMediaAnalysis.BLL.Options;

public class NlpOptionsSetup: IConfigureOptions<NlpOptions>
{
    private const string SectionName = NlpOptions.SectionName;
    private readonly IConfiguration _configuration;

    public NlpOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void Configure(NlpOptions options)
    {
        _configuration
            .GetSection(SectionName)
            .Bind(options);
    }
}