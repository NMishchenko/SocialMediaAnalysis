using SocialMediaAnalysis.BLL.Enums;

namespace SocialMediaAnalysis.BLL.Models.News;

public class EverythingResponseModel
{
    public Status Status { get; set; }
    public ErrorModel Error { get; set; }
    public int TotalResults { get; set; }
    public IEnumerable<ArticleModel> Articles { get; set; }
}