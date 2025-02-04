using System.Net;
using ProjectName.Domain.Enums;
using ProjectName.Domain.Exceptions;

namespace ProjectName.Api.Middlewares
{
    internal class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            _logger.LogError("Exception occurred. {Exception}", exception);

            if(exception is BusinessException businessException)
            {
                await HandleBusinessExceptionAsync(httpContext, businessException);
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.CompleteAsync();
            }
        }

        private async Task HandleBusinessExceptionAsync(HttpContext httpContext, BusinessException businessException)
        {
            switch(businessException.Type)
            {
                case ExceptionType.NotFound:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case ExceptionType.BadRequest:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }

            await httpContext.Response.WriteAsJsonAsync(businessException.Data);
        }
    }

    internal static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
