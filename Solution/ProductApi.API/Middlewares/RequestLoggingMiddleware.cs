using System.Diagnostics;

namespace ProductApi.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();

                var logMessage =
                    $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | " +
                    $"Method: {context.Request.Method} | " +
                    $"Path: {context.Request.Path} | " +
                    $"StatusCode: {context.Response.StatusCode} | " +
                    $"ResponseTime: {stopwatch.ElapsedMilliseconds} ms";


                var logPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Logs",
                    "requests.txt");


                Directory.CreateDirectory(
                    Path.GetDirectoryName(logPath)!);


                await File.AppendAllTextAsync(
                    logPath,
                    logMessage + Environment.NewLine);


                _logger.LogInformation(logMessage);
            }
        }
    }
}