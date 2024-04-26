using Carter;
using Application.Features.Torneos.Create;
using Application.Features.Torneos.Get;
using MediatR;

using Domain.Entities;
using FluentResults;

namespace WebApi.Endpoints;

public class TorneoModule() : CarterModule("torneo")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", CreateTorneo)
            .WithName("CreateTorneo")
            .WithOpenApi();

        app.MapGet("/{id}", GetTorneo)
        .WithName("GetTorneoWithId")
        .WithOpenApi();
    }

    private async Task<IResult> CreateTorneo(CreateTorneoRequest request, ISender sender)
    {
        Torneo torneo = Torneo.Create(
            request.Nombre,
            request.Liga,
            request.Comentarios ?? string.Empty);

        var command = new CreateTorneoCommand(torneo);
        Result<Guid> result = await sender.Send(command);

        return Results.Ok(result.Value);
    }

    private async Task<IResult> GetTorneo(Guid id, ISender sender)
    {
        GetTorneoQuery query = new(id);
        Result<GetTorneoResponse> result = await sender.Send(query);

        return Results.Ok(result.Value);
    }
}