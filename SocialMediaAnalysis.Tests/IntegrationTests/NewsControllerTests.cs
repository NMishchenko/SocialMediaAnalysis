using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using SocialMediaAnalysis.PL;

namespace SocialMediaAnalysis.Tests.IntegrationTests;

[TestFixture]
public class NewsControllerTests: IDisposable
{
    private readonly WebApplicationFactory<Startup> _factory;
    private readonly HttpClient _client;
    
    public NewsControllerTests()
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
    public async Task GetEverything_Returns_OK()
    {
        const string url = "/api/v1/news?q=test";

        var response = await _client.GetAsync(url);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    
    [Test]
    public async Task GetSources_Returns_OK()
    {
        const string url = "/api/v1/news/sources";

        var response = await _client.GetAsync(url);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}