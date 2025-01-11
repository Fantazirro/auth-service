using AuthService.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Middleware
{
    public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {         
            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var isInternalServerError = httpContext.Response.StatusCode == StatusCodes.Status500InternalServerError;

            var logLevel = isInternalServerError ? LogLevel.Error : LogLevel.Information;
            logger.Log(logLevel, $"An error occured: {exception.Message}");

            var problemDetails = new ProblemDetails()
            {
                Type = exception.GetType().Name,
                Status = httpContext.Response.StatusCode,
                Title = "An error occured",
                Detail = isInternalServerError ? "Internal Server Error" : exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            };         

            await httpContext.Response.WriteAsJsonAsync(problemDetails);

            return true;
        }
    }
}