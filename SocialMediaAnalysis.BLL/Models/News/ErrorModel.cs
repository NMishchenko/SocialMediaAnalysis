using SocialMediaAnalysis.BLL.Enums;

namespace SocialMediaAnalysis.BLL.Models.News;

public class ErrorModel
{
    public ErrorCode Code { get; set; }
    public string Message { get; set; }
}