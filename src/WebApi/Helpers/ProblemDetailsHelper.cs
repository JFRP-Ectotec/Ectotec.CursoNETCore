// <copyright file="ProblemDetailsHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using FluentResults;

namespace WebApi.Helpers;

/// <summary>
/// Clase auxiliar para construir ProblemDetails en base a un FluentResult.
/// </summary>
public static class ProblemDetailsHelper
{
    /// <summary>
    /// Convertidor básico de FluentResult a ProblemDetails.
    /// </summary>
    /// <param name="result">FluentResult obtenido de una operación.</param>
    /// <param name="statusCode">Estatus que debe registrarse en el resultado. Default 500.</param>
    /// <returns>ProblemDetails en base al FluentResult.</returns>
    public static IResult Convierte(
        IResultBase result,
        int statusCode = StatusCodes.Status500InternalServerError)
    {
        return Results.Problem(
            // detail: string.Join(
            //     ", ", 
            //     result.Reasons.Select(reason => reason.Message)),
            detail: result.Reasons.FirstOrDefault().Message,
            statusCode: statusCode,
            extensions: new Dictionary<string, object?>
            {
                { "errors", new[] { result.Reasons } },
            }
        );

        // title: result.Errors.FirstOrDefault()?.Message ?? "Unknown Error"
        // Extensions = new Dictionary<string, object?>
        // {
        //     { "errors", new[] { result.Errors } },
        // };
    }
}