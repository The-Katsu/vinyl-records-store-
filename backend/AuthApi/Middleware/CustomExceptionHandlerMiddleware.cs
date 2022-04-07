namespace AuthApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger) 
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (ex)
            {
                case Exception exception:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new {error = ex.Message});
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
                result = JsonSerializer.Serialize(new {error = ex.Message});

            _logger.LogError(ex.Message);

            return context.Response.WriteAsync(result);
        }
    }
}