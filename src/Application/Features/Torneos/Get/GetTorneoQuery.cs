using FluentResults;

using MediatR;

namespace Application.Features.Torneos.Get;

/// <summary>
/// Estructura para peticiones de obtener escenarios.
/// </summary>
/// <param name="Id">Id del escenario a obtener.</param>
public record GetTorneoQuery(Guid Id) : IRequest<Result<GetTorneoResponse>>;