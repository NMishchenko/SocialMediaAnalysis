namespace SocialMediaAnalysis.BLL.Options;

public class NlpOptions
{
    public string AzureKey { get; set; }
    public string AzureEndpoint { get; set; }
    
    public const string SectionName = "NlpSettings";
}