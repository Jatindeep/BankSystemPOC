using Application.Interfaces.Command;
using System.Net;
using System.Text.Json;
using Web.Models;

namespace Web.Extensions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILoggerCommandRepository _logger = default!;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILoggerCommandRepository logger)
        {
            try
            {
                _logger = logger;
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
                throw;
            }
        }

        /// <summary>
        /// Add Exception Log
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            var errorResponse = new ErrorDetailsModel()
            {
                StatusCode = response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            };

            switch (exception)
            {
                case ApplicationException ex:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = ex.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal server error!";
                    break;
            }
            _logger.AddExceptionLog(exception.Message, exception.StackTrace ?? string.Empty, string.Empty);
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
    }
}
