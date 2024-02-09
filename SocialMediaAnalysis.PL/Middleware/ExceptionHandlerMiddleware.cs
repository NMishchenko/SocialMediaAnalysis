using SocialMediaAnalysis.BLL.Exceptions;
using System.Net;
using System.Text.Json;
using FluentValidation;

namespace SocialMediaAnalysis.PL.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var response = httpContext.Response;
        response.ContentType = "application/json";
        var responseBody = String.Empty;

        try
        {
            await _next(httpContext);
        }
        catch (BadRequestException exception)
        {
            responseBody = JsonSerializer.Serialize(new { message = exception?.Message });

            response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        catch (NotFoundException exception)
        {
            responseBody = JsonSerializer.Serialize(new { message = exception?.Message });

            response.StatusCode = (int)HttpStatusCode.NotFound;
        }
        catch (ValidationException exception)
        {
            responseBody = JsonSerializer.Serialize(new { message = exception?.Message });

            response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        catch (Exception exception)
        {
            responseBody = JsonSerializer.Serialize(new { message = exception?.Message });

            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            _logger.LogError(exception.ToString());
        }

        if (response.StatusCode != StatusCodes.Status204NoContent)
        {
            await response.WriteAsync(responseBody);
        }
    }
}