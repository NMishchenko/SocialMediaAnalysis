using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SocialMediaAnalysis.BLL.Utility;

public static class HttpClientExtensions
{
    public static async Task<TResponse> GetAsync<TResponse>(
        this HttpClient httpClient,
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        var response = await httpClient
            .GetAsync(requestUri, cancellationToken);
        
        response.EnsureSuccessStatusCode();
        
        var stringContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<TResponse>(stringContent);
    }

    public static async Task<TResponse> CreateAsync<TResponse, TRequest>(
        this HttpClient httpClient,
        string requestUri,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        var serializedContent = JsonSerializer.Serialize(request, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        });
        var content = new StringContent(serializedContent);
        var response = await httpClient
            .PostAsync(requestUri, content, cancellationToken);

        response.EnsureSuccessStatusCode();

        var stringContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TResponse>(stringContent);
    }

    public static async Task<TResponse> UpdateAsync<TResponse, TRequest>(
        this HttpClient httpClient,
        string requestUri,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        var serializedContent = JsonSerializer.Serialize(request, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        });
        var content = new StringContent(JsonSerializer.Serialize(serializedContent));
        var response = await httpClient
            .PutAsync(requestUri, content, cancellationToken);

        response.EnsureSuccessStatusCode();

        var stringContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TResponse>(stringContent);
    }

    public static async Task<TResponse> DeleteAsync<TResponse>(
        this HttpClient httpClient,
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);

        response.EnsureSuccessStatusCode();
        
        var stringContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TResponse>(stringContent);
    }
}