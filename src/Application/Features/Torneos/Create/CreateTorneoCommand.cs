using Domain.Entities;

using FluentResults;

using MediatR;

namespace Application.Features.Torneos.Create;

/// <summary>
/// Record para representar la creación de un escenario deportivo.
/// </summary>
/// <param name="Tournament">Escenario.</param>
public record CreateTorneoCommand(Torneo Tournament) : IRequest<Result<Guid>>;