using FluentValidation;
using InventoryManagementSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace InventoryManagementSystem.API.ExceptionHandlers
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "An unhandled exception occurred while processing the request. : {Message}", exception.Message);

            var (statusCode, title) = exception switch
            {
                ValidationException => (StatusCodes.Status400BadRequest, "Validation Error"),
                NotFoundException => (StatusCodes.Status404NotFound, "Not Found"),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
            };
            httpContext.Response.StatusCode = statusCode;

            var response = new
            {
                Status = statusCode,
                Title = title,
                Detail = exception.Message,
                Errors = exception is ValidationException validationException ? validationException.Errors.
                GroupBy(E => E.PropertyName).ToDictionary(G => G.Key, G => G.Select(E => E.ErrorMessage)) : null
            };

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
