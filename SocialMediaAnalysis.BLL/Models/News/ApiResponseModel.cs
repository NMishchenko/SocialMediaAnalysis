﻿using Newtonsoft.Json;
using SocialMediaAnalysis.BLL.Models.Analysis;

namespace SocialMediaAnalysis.BLL.Models.News;

public class ApiResponseModel
{
    [JsonProperty("articles")]
    public List<ArticleModel> Articles { get; set; }
    
    [JsonProperty("totalResults")]
    public int TotalResults { get; set; }
    
    [JsonProperty("chartData")]
    public IEnumerable<ChartDataModel> ChartData { get; set; }
}