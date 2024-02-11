using System.Net;
using Polly;
using Polly.Retry;

namespace SocialMediaAnalysis.BLL.HttpHandlers;

public class RetryHttpHandler: DelegatingHandler
{
    private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

    public RetryHttpHandler()
    {
        _retryPolicy = Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .OrResult(response => response.StatusCode == HttpStatusCode.BadRequest)
            .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
            );
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var policyResult = await _retryPolicy.ExecuteAndCaptureAsync(
            () => base.SendAsync(request, cancellationToken));
        if (policyResult.Outcome == OutcomeType.Failure)
        {
            throw new HttpRequestException("Something went wrong", policyResult.FinalException);
        }

        return policyResult.Result;
    }
}