using System.Net;

namespace SocialMediaAnalysis.BLL.HttpClients.NewsApi.Handlers;

public class ExceptionHttpHandler: DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, 
        CancellationToken cancellationToken)
    {
        try
        {
            return await base.SendAsync(request, cancellationToken);
        }
        catch (Exception ex)
        {
            // TODO: add proper error handling
            
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }
}