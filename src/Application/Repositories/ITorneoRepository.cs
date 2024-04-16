using Domain.Entities;
using FluentResults;

namespace Application.Repositories;

public interface ITorneoRepository
{

    /// <summary>
    /// Obtener todos los torneos del almacenamiento.
    /// </summary>
    /// <returns>Torneos de la BD..</returns>
    Task<Result<ICollection<Torneo>>> GetAll();

    /// <summary>
    /// Obtener un torneo del almacenamiento.
    /// </summary>
    /// <param name="id">Identificador del torneo.</param>
    /// <returns>Torneo de la BD acorde al id enviado o error.</returns>
    Task<Result<Torneo>> Get(Guid id);

    /// <summary>
    /// Agregar un torneo al almacenamiento.
    /// </summary>
    /// <param name="torneo">Torneo a agregar.</param>
    /// <returns>Objeto result indicando éxito o fracaso de la adición.</returns>
    Task<Result> Add(Torneo torneo);

    /// <summary>
    /// Modificar un torneo del almacenamiento.
    /// </summary>
    /// <param name="id">Identificador del escenario.</param>
    /// <param name="torneo">Torneo con los valores a sobreescribir.</param>
    /// <returns>Torneo de la BD acorde al id enviado o error.</returns>
    Task<Result<Torneo>> Modify(Guid id, Torneo torneo);

    /// <summary>
    /// Borrar un torneo del almacenamiento.
    /// </summary>
    /// <param name="id">Identificador del escenario.</param>
    /// <returns>Objeto result indicando éxito o fracaso del borrado.</returns>
    Task<Result> Remove(Guid id);

    Task<Result<Torneo>> AddPosicion(Guid id, Posicion torneo);
}