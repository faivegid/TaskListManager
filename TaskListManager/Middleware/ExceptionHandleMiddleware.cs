using Newtonsoft.Json;
using System.Net;
using TaskListManager.Shared.Exceptions;
using TaskListManager.Shared.Responses;

namespace TaskListManager.Middleware
{
    public class ExceptionHandleMiddleware
    {
        ILogger<ExceptionHandleMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next, ILogger<ExceptionHandleMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiCallException ax)
            {
                _logger.LogError(ax, $"An error occurred while processing the request. stackTrace: {ax.StackTrace}");
                var response = ApiResponse.Error(ax.ErrorMessage);

                if (ax.ErrorCode == HttpStatusCode.NotFound)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }

                context.Response.StatusCode = response.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while processing the request.");
                var response = ApiResponse.Error(ex.Message, HttpStatusCode.InternalServerError);

                context.Response.StatusCode = response.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
