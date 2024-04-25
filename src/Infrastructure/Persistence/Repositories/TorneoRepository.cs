using Application.Repositories;
using Domain.Entities;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Domain.Errors.Errors;

namespace Infrastructure.Persistence.Repositories;

public class TorneoRepository(
    ApplicationDbContext dbContext,
    ILogger<TorneoRepository> logger) : ITorneoRepository
{
    private async Task<List<string>> ValidacionesExtra(Torneo torneo)
    {
        List<string> errores = [];

        Torneo? torneoBD = await dbContext.Torneos.FirstOrDefaultAsync(
            t => t.Nombre == torneo.Nombre && t.Liga == t.Liga);
        if (torneoBD is not null)
        {
            errores.Add(ErrorTorneo.Existente(torneo.Nombre, torneo.Liga).Description);
        }

        return errores;
    }

    public async Task<Result> Add(Torneo torneo)
    {
        List<string> validacionesExtra = await ValidacionesExtra(torneo);
        if (validacionesExtra.Count > 0)
        {
            return Result.Fail(validacionesExtra);
        }

        await dbContext.Torneos.AddAsync(torneo);

        return Result.Ok();
    }

    public Task<Result<Torneo>> AddPosicion(Guid id, Posicion torneo)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Torneo>> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ICollection<Torneo>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Result<Torneo>> Modify(Guid id, Torneo torneo)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Remove(Guid id)
    {
        throw new NotImplementedException();
    }
}
