using Newtonsoft.Json;
using SocialMediaAnalysis.BLL.Models.Analysis;

namespace SocialMediaAnalysis.BLL.HttpClients.NewsApi.Models.NewsApi;

public class ApiResponseModel
{
    [JsonProperty("articles")]
    public List<ArticleModel> Articles { get; set; }
    
    [JsonProperty("totalResults")]
    public int TotalResults { get; set; }
    
    [JsonIgnore]
    public IEnumerable<ChartDataModel> ChartData { get; set; }
}