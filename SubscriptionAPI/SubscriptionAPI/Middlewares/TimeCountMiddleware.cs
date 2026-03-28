using System.Diagnostics;

namespace SubscriptionAPI.Middlewares
{
    public class TimeCountMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TimeCountMiddleware> _logger; 

        public TimeCountMiddleware(ILogger<TimeCountMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var st = Stopwatch.StartNew();

            await _next(context);

            st.Stop();

            _logger.LogInformation("Запит {Method} {Path} завершено за {ElapsedMilliseconds} мс зі статусом {StatusCode}",
                context.Request.Method,
                context.Request.Path,
                st.ElapsedMilliseconds,
                context.Response.StatusCode);
        }
    }
}
