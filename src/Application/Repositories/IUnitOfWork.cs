namespace Application.Repositories;

/// <summary>
/// Interfaz para representar la UnitOfWork.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Método para grabar cambios a una base de datos.
    /// </summary>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}