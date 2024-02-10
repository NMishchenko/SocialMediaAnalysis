using SocialMediaAnalysis.BLL.Enums;

namespace SocialMediaAnalysis.BLL.HttpClients.NewsApi.Models.NewsApi;

public class ErrorModel
{
    public ErrorCode Code { get; set; }
    public string Message { get; set; }
}