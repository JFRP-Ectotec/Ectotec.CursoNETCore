using Application.Repositories;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Features.Torneos.Create;

public sealed class CreateTorneoCommandHandler(
    ITorneoRepository torneoRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateTorneoCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateTorneoCommand request, CancellationToken cancellationToken)
    {
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
