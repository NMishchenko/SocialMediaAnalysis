using Microsoft.AspNetCore.Mvc;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Interfaces;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Models.NewsApi;

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
    public async Task<IActionResult> Get([FromQuery] EverythingRequestModel request)
    {
        var response = await _newsApiService.GetEverythingAsync(request);
        return Ok(response);
    }
}