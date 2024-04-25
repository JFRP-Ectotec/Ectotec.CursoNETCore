using Application.Repositories;
using Domain.Entities;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Torneos.Create;

public sealed class CreateTorneoCommandHandler(
    ITorneoRepository torneoRepository,
    IUnitOfWork unitOfWork,
    ILogger<CreateTorneoCommandHandler> logger
) : IRequestHandler<CreateTorneoCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateTorneoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("LLamada a crear torneo.");
        logger.LogDebug(request.Tournament.ToString());
        Torneo torneo = request.Tournament;
        Result llamadaAgregar = await torneoRepository.Add(torneo);

        if (llamadaAgregar.IsFailed)
        {
            return llamadaAgregar;
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok(torneo.Id);
    }
}
