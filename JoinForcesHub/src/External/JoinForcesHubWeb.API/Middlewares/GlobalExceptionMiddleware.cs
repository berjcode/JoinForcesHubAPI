using System.Net;
using System.Net.Mime;
using System.Text.Json;
using JoinForcesHubWeb.API.Utilities;
using JoinForcesHubWeb.API.Utilities.Messages;

namespace JoinForcesHubWeb.API.Middlewares;

public class GlobalExceptionMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger, IHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = _env.IsDevelopment()
               ? new CustomResponse(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
               : new CustomResponse(context.Response.StatusCode, ApiMessages.InternalServerError);

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var json = JsonSerializer.Serialize(response, options);
        await context.Response.WriteAsync(json);
    }
}
