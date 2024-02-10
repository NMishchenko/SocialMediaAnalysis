using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using Microsoft.Extensions.Options;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Interfaces;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Models.NewsApi;
using SocialMediaAnalysis.BLL.Options;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.BLL.Services;

public class RssFeedService: IRssFeedService
{
    private readonly INewsApiService _newsApiService;
    private readonly ApplicationOptions _applicationOptions;

    public RssFeedService(
        INewsApiService newsApiService,
        IOptions<ApplicationOptions> applicationOptions)
    {
        _newsApiService = newsApiService;
        _applicationOptions = applicationOptions.Value;
    }
    
    public async Task<byte[]> GetNewsRssFeedAsync(EverythingRequestModel everythingRequestModel)
    {
        var feed = new SyndicationFeed
        {
            Copyright = new TextSyndicationContent($"{DateTime.Now.Year} ModernCrusaders"),
            Title = new TextSyndicationContent("News RSS feed"),
            BaseUri = new Uri(_applicationOptions.AppUrl),
            LastUpdatedTime = DateTime.UtcNow
        };
        
        var items = new List<SyndicationItem>();

        var news = await _newsApiService.GetEverythingAsync(everythingRequestModel);

        foreach (var newsArticle in news.Articles)
        {
            var newsUri = new Uri(newsArticle.Url);
            items.Add(new SyndicationItem(newsArticle.Title, newsArticle.Description, newsUri));
        }
        
        feed.Items = items;
        
        var settings = new XmlWriterSettings
        {
            Async = true,
            Encoding = Encoding.UTF8,
            NewLineHandling = NewLineHandling.Entitize,
            NewLineOnAttributes = true,
            Indent = true
        };
        using var stream = new MemoryStream();
        await using (var xmlWriter = XmlWriter.Create(stream, settings))
        {
            var rssFormatter = new Rss20FeedFormatter(feed, false);
            rssFormatter.WriteTo(xmlWriter);
            await xmlWriter.FlushAsync();
        }

        return stream.ToArray();
    }
}