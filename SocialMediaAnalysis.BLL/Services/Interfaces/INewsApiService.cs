using SocialMediaAnalysis.BLL.Models.News;

namespace SocialMediaAnalysis.BLL.Services.Interfaces;

public interface INewsApiService
{
    Task<ApiResponseModel> GetEverythingAsync(EverythingRequestModel request);
}