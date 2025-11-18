using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace TaskManager_WebAPI.WebAPI.Middleware
{
    public class ExceptionMiddleware(RequestDelegate Next, ILogger<ExceptionMiddleware> Logger)
    {
        public async Task InvokeAsync(HttpContext Context)
        {
            try
            {
                await Next(Context); 
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Произошло необработанное исключение");
                await HandleExceptionAsync(Context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; 
            var result = JsonSerializer.Serialize(new { error = exception.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

}
