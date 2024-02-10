using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Models.NewsApi;

namespace SocialMediaAnalysis.BLL.HttpClients.NewsApi.Interfaces;

public interface INewsApiService
{
    Task<ApiResponseModel> GetEverythingAsync(EverythingRequestModel request);
    Task<SourcesResponseModel> GetSourcesAsync();
}