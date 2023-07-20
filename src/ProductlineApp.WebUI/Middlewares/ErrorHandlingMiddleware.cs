using System.Net;
using ProductlineApp.Application.Common.Contexts;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProductlineApp.WebUI.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlingMiddleware> logger)
    {
        this._next = next;
        this._logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await this._next(context);
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, "An error occured");

            var loggingRepository = context.RequestServices.GetService<ILoggingRepository>();
            await loggingRepository.LogError(ex);
            await HandleExceptionAsync(context);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context)
    {
        const HttpStatusCode code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new { error = "Server error occured. Check logs for more details." });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        await context.Response.WriteAsync(result);
    }
}
