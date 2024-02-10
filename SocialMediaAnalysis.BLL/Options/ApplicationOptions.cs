namespace SocialMediaAnalysis.BLL.Options;

public class ApplicationOptions
{
    public string ApiUrl { get; set; }
    public string AppUrl { get; set; }
    
    public const string SectionName = "ApplicationSettings";
}