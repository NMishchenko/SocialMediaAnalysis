using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Interfaces;
using SocialMediaAnalysis.BLL.HttpClients.NewsApi.Models.NewsApi;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.BLL.Services;

public class RssFeedService: IRssFeedService
{
    private readonly INewsApiService _newsApiService;

    public RssFeedService(INewsApiService newsApiService)
    {
        _newsApiService = newsApiService;
    }
    
    public async Task<byte[]> GetNewsRssFeedAsync(EverythingRequestModel everythingRequestModel)
    {
        var feed = new SyndicationFeed
        {
            Copyright = new TextSyndicationContent($"{DateTime.Now.Year} ModernCrusaders"),
            Title = new TextSyndicationContent("News RSS feed"),
            BaseUri = new Uri("https://example.com"),
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