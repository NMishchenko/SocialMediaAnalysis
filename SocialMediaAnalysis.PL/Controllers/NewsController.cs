using Microsoft.AspNetCore.Mvc;
using SocialMediaAnalysis.BLL.Models.News;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.PL.Controllers;

[ApiController]
[Route("/api/v1/news")]
public class NewsController: ControllerBase
{
    private readonly INewsApiService _newsApiService;

    public NewsController(INewsApiService newsApiService)
    {
        _newsApiService = newsApiService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEverything([FromQuery] EverythingRequestModel request)
    {
        var response = await _newsApiService.GetEverythingAsync(request);
        return Ok(response);
    }

    [HttpGet("sources")]
    public async Task<IActionResult> GetSources()
    {
        var response = await _newsApiService.GetSourcesAsync();
        return Ok(response);
    }
}