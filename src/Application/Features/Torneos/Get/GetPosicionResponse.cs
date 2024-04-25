namespace Application.Features.Torneos.Get;

/// <summary>
/// Record para representar la creación de un escenario deportivo.
/// </summary>
/// <param name="Equipo">Nombre del equipo.</param>
/// <param name="Ganados">Juegos ganados.</param>
/// <param name="Perdidos">Juegos perdidos..</param>
/// <param name="Porcentaje">Porcentaje de efectividad.</param>
/// <param name="Empates">Juegos empatados.</param>
/// <param name="Puntos">Puntos obtenidos.</param>
public record GetPosicionResponse(
    string Etapa,
    string Grupo,
    string Equipo,
    int Ganados,
    int Perdidos,
    float Porcentaje,
    int? Empates,
    int? Puntos);