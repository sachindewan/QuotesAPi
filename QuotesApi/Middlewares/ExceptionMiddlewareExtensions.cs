using Microsoft.AspNetCore.Builder;

namespace QuotesApi.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorWrappingMiddleware>();
        }
    }
}
