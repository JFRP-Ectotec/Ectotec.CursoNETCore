namespace Application.Features.Torneos.Get;

/// <summary>
/// Record para representar la creación de un escenario deportivo.
/// </summary>
/// <param name="Nombre">Nombre del escenario.</param>
/// <param name="Liga">Liga en la que aplica.</param>
/// <param name="Comentarios">Comentarios del torneo.</param>
/// <param name="Posiciones">Etapas del escenario.</param>
public record GetTorneoResponse(
    string Nombre,
    string Liga,
    string Comentarios,
    ICollection<GetPosicionResponse> Posiciones);