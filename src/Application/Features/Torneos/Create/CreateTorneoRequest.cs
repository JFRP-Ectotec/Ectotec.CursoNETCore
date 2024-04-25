namespace Application.Features.Torneos.Create;

public record CreateTorneoRequest(
    string Nombre,
    string Liga,
    ICollection<CreatePosicionRequest> Posiciones,
    string? Comentarios = "");