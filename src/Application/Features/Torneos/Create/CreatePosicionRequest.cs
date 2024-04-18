namespace Application.Features.Torneos.Create;

/// <summary>
/// Record para representar la creación de un escenario deportivo.
/// </summary>
/// <param name="Club">Nombre del equipo.</param>
/// <param name="Ganados">Juegos ganados.</param>
/// <param name="Perdidos">Juegos perdidos.</param>
/// <param name="Empates">Juegos empatados.</param>
/// <param name="Puntos">Puntos obtenidos.</param>
public record CreatePosicionRequest(
    string Etapa,
    string Grupo,
    string Club,
    int Ganados,
    int Perdidos,
    int? Empates = 0,
    int? Puntos = 0);