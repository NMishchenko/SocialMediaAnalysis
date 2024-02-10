using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Models.NewsApi;

namespace SocialMediaAnalysis.BLL.Services.Interfaces;

public interface IRssFeedService
{
    Task<byte[]> GetNewsRssFeedAsync(EverythingRequestModel everythingRequestModel);
}