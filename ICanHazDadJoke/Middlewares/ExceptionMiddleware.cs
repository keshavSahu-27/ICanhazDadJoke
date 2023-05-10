using System;
namespace ICanHazDadJoke.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await httpContext.Response.WriteAsync(
                    $"StatusCode = {httpContext.Response.StatusCode}\nMessage = {ex.Message}"
                 );
            }
        }
    }
}

