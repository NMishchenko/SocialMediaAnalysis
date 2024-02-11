using SocialMediaAnalysis.BLL.Models.News;

namespace SocialMediaAnalysis.BLL.Services.Interfaces;

public interface IRssFeedService
{
    Task<byte[]> GetNewsRssFeedAsync(EverythingRequestModel everythingRequestModel);
}