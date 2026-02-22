namespace SubscriptionAPI.Middlewares
{
    public class MessageMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MessageMiddleware> _logger;

        public MessageMiddleware(RequestDelegate next, ILogger<MessageMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            _logger.LogInformation($"Copyright by Alina");
        }
    }
}
