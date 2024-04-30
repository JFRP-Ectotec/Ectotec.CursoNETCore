// <copyright file="GlobalExceptionHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Diagnostics;

namespace WebApi.Helpers;

/// <summary>
/// Clase para manejo global de Excepciones.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GlobalExceptionHandler"/> class.
/// </remarks>
/// <param name="logger">Para realizar logs.</param>
/// <param name="problemDetailsService">Para convertir a ProblemDetails.</param>
public class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    IProblemDetailsService problemDetailsService)
    : IExceptionHandler
{
    /// <inheritdoc/>
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails =
                {
                    Title = "An error occurred",
                    Detail = exception.Message,
                    Type = exception.GetType().Name,
                },
            Exception = exception,
        });
    }
}