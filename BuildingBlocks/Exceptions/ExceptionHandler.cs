using FluentValidation;
using BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks;

public class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> logger;
    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        this.logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var exceptionMessage = exception.Message;

        var status = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            BadRequestException or ValidationException => StatusCodes.Status400BadRequest,
            InternalServerException => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };

        var problemDetails = new ProblemDetails
        {
            Title = exception.GetType().Name,
            Status = status,
            Detail = exceptionMessage,
            Instance = context.Request.Path
        };

        problemDetails.Extensions.Add("traceId", context.TraceIdentifier);

        if (exception is ValidationException validationException)
            problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);

        context.Response.StatusCode = status;

        logger.LogError(
            "Error Message: {exceptionMessage}, Time of occurrence {time}",
            exceptionMessage, DateTime.UtcNow);

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
