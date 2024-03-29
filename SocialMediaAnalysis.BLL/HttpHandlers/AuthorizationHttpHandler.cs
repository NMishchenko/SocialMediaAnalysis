﻿using Microsoft.Extensions.Options;
using SocialMediaAnalysis.BLL.Options;

namespace SocialMediaAnalysis.BLL.HttpHandlers;

public class AuthorizationHttpHandler: DelegatingHandler
{
    private readonly NewsApiAuthOptions _newsApiAuthOptions;

    public AuthorizationHttpHandler(IOptions<NewsApiAuthOptions> newsApiAuthOptions)
    {
        _newsApiAuthOptions = newsApiAuthOptions.Value;
    }
    
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, 
        CancellationToken cancellationToken)
    {
        request.Headers.Add("X-Api-Key", _newsApiAuthOptions.ApiKey);
        request.Headers.Add("User-Agent", "ModernMediaAnalyzer API");
        
        return await base.SendAsync(request, cancellationToken);
    }
}