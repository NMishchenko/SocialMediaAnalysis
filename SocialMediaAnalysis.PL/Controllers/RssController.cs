using Microsoft.AspNetCore.Mvc;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Models.NewsApi;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.PL.Controllers;

[ApiController]
[Route("api/v1/rss")]
public class RssController
{
    private readonly IRssFeedService _rssFeedService;

    public RssController(IRssFeedService rssFeedService)
    {
        _rssFeedService = rssFeedService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] EverythingRequestModel request)
    {
        var rssByteArray = await _rssFeedService.GetNewsRssFeedAsync(request);
        return new FileContentResult(rssByteArray, "application/rss+xml; charset=utf-8");
    }
}