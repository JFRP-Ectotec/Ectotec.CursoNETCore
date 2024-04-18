using System.Collections.ObjectModel;

using Application.Repositories;
using Domain.Entities;
using FluentResults;

using MediatR;

namespace Application.Features.Torneos.Get;

/// <summary>
/// Handler para manejar obtener un escenario.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetTorneoQueryHandler"/> class.
/// </remarks>
/// <param name="torneoRepository">Repositorio para manejo de Escenarios.</param>
internal class GetTorneoQueryHandler(
    ITorneoRepository torneoRepository)
    : IRequestHandler<GetTorneoQuery, Result<GetTorneoResponse>>
{
    /// <summary>
    /// Método que maneja la petición de obtención de escenario deportivo.
    /// </summary>
    /// <param name="request">Petición de obtener escenario deportivo.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>Escenario acorde al Id proporcionado.</returns>
    public async Task<Result<GetTorneoResponse>> Handle(
        GetTorneoQuery request,
        CancellationToken cancellationToken)
    {
        Result<Torneo> torneoResult = await torneoRepository.Get(request.Id);
        if (torneoResult.IsFailed)
        {
            List<string> errores = [];
            torneoResult.Errors.ForEach(
                e => errores.Add(e.Message));
            return Result.Fail(errores);
        }

        Torneo torneo = torneoResult.Value;

        List<GetPosicionResponse> posiciones = [];
        torneo.Posiciones.ToList().ForEach(
            p =>
            {
                posiciones.Add(
                    new GetPosicionResponse(
                        p.Id.Etapa,
                        p.Id.Grupo,
                        p.Id.Club,
                        p.Ganados,
                        p.Perdidos,
                        p.Porcentaje,
                        p.Empates,
                        p.Puntos));
            }
        );

        return Result.Ok(
            new GetTorneoResponse(
                torneo.Nombre,
                torneo.Liga,
                torneo.Comentarios,
                posiciones));
    }
}