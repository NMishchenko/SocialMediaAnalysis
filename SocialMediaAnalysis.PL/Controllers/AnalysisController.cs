using Microsoft.AspNetCore.Mvc;
using SocialMediaAnalysis.BLL.Models.Analysis;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.PL.Controllers;

[ApiController]
[Route("/api/v1/analysis")]
public class AnalysisController : ControllerBase
{
    private readonly IAnalysisService _analysisService;

    public AnalysisController(IAnalysisService analysisService)
    {
        _analysisService = analysisService;
    }

    [HttpPost]
    public async Task<IActionResult> GetAnalysis([FromBody] AnalysisInputModel analysisInputModel)
    {
        var response = await _analysisService.GetAnalysisAsync(analysisInputModel);
        return Ok(response);
    }
}