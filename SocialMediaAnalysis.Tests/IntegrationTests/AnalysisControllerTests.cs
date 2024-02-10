using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using SocialMediaAnalysis.BLL.Models.Analysis;
using SocialMediaAnalysis.PL;
using SocialMediaAnalysis.Tests.ModelBuilders.Analysis;

namespace SocialMediaAnalysis.Tests.IntegrationTests;

[TestFixture]
public class AnalysisControllerTests: IDisposable
{
    private readonly WebApplicationFactory<Startup> _factory;
    private readonly HttpClient _client;
    
    public AnalysisControllerTests()
    {
        _factory = new WebApplicationFactory<Startup>();
        _client = _factory.CreateClient();
    }
    
    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
    
    [Test]
    public async Task GetAnalysis_Returns_OK()
    {
        const string url = "/api/v1/analysis";
        var analysisInputModel = new AnalysisInputModelBuilder().Build();

        var stringContent = new StringContent(
            JsonConvert.SerializeObject(analysisInputModel), 
            Encoding.UTF8, 
            "application/json");
        
        var response = await _client.PostAsync(url, stringContent);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    
    [TestCase("https://bbc.com")]
    [TestCase("https://edition.cnn.com/")]
    public async Task GetAnalysis_Returns_OK(string uri)
    {
        const string url = "/api/v1/analysis";
        var analysisInputModel = new AnalysisInputModel
        {
            PageUrl = uri
        };

        var stringContent = new StringContent(
            JsonConvert.SerializeObject(analysisInputModel), 
            Encoding.UTF8, 
            "application/json");
        
        var response = await _client.PostAsync(url, stringContent);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}