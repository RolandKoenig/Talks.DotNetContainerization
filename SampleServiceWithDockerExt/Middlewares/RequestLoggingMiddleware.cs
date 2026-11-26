using System.Diagnostics;

namespace Talks.DotNetContainerization.SampleService.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    
    public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
    }
    
    public async Task Invoke(HttpContext context)
    {
        var stopWatch = Stopwatch.StartNew();
        try
        {
            await _next(context);
        }
        finally
        {
            stopWatch.Stop();

            _logger.LogInformation(
                "Processed request {Method} {Url}. Response: {StatusCode} in {Time:F2} ms",
                context.Request?.Method,
                $"{context.Request?.Host}/{context.Request?.Path.Value}",
                context.Response?.StatusCode.ToString() ?? "(no status)",
                stopWatch.Elapsed.TotalMilliseconds);
        }
    }
}