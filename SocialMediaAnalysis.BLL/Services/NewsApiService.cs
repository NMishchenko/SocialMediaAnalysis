﻿using SocialMediaAnalysis.BLL.Models.Analysis;
using SocialMediaAnalysis.BLL.Models.News;
using SocialMediaAnalysis.BLL.Services.Interfaces;
using SocialMediaAnalysis.BLL.Utility;

namespace SocialMediaAnalysis.BLL.Services;

public class NewsApiService: INewsApiService
{
    private readonly HttpClient _httpClient;
    
    private const string BaseUri = Constants.Constants.NewsApi.BaseUri;

    public NewsApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ApiResponseModel> GetEverythingAsync(EverythingRequestModel request)
    {
        var queryString = GetEverythingQueryString(request);
        var response = await MakeGetRequest<ApiResponseModel>("everything", queryString);
        
        response.ChartData = Enumerable.Range(1, 30)
            .Select(day =>
            {
                var date = DateTime.Now.Date.AddDays(-day);
                return new ChartDataModel()
                {
                    Date = date,
                    TotalNumber = response.Articles
                        .Count(a => a.PublishedAt.HasValue && a.PublishedAt.Value.Date == date)
                };
            })
            .OrderBy(c => c.Date);
        
        return response;
    }

    public async Task<SourcesResponseModel> GetSourcesAsync()
    {
        var response = await MakeGetRequest<SourcesResponseModel>("top-headlines/sources", "language=en");
        return response;
    }

    private static string GetEverythingQueryString(EverythingRequestModel request)
    {
        var queryParams = new List<string>();

        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            queryParams.Add("q=" + request.Q);
        }
        
        if (request.SearchIn.Count > 0)
        {
            queryParams.Add("searchIn=" + string.Join(",", request.Sources));
        }
        
        if (request.Sources.Count > 0)
        {
            queryParams.Add("sources=" + string.Join(",", request.Sources));
        }

        if (request.Domains.Count > 0)
        {
            queryParams.Add("domains=" + string.Join(",", request.Sources));
        }
        
        if (request.ExcludeDomains.Count > 0)
        {
            queryParams.Add("excludeDomains=" + string.Join(",", request.Sources));
        }

        if (request.From.HasValue)
        {
            queryParams.Add("from=" + $"{request.From.Value:s}");
        }

        if (request.To.HasValue)
        {
            queryParams.Add("to=" + $"{request.To.Value:s}");
        }

        if (request.Language.HasValue)
        {
            queryParams.Add("language=" + request.Language.Value.ToString().ToLowerInvariant());
        }

        if (request.SortBy.HasValue)
        {
            queryParams.Add("sortBy=" + request.SortBy.Value);
        }

        if (request.PageSize > 0)
        {
            queryParams.Add("pageSize=" + request.PageSize);
        }
        
        if (request.Page > 1)
        {
            queryParams.Add("page=" + request.Page);
        }

        return string.Join("&", queryParams.ToArray());
    }
    
    private async Task<TResponse> MakeGetRequest<TResponse>(string endpoint, string? queryString = null)
    {
        var requestUri = BaseUri + endpoint;

        if (!string.IsNullOrWhiteSpace(queryString))
        {
            requestUri += $"?{queryString}";
        }

        return await _httpClient.GetAsync<TResponse>(requestUri);
    }
}