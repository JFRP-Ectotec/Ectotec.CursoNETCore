using Domain.Abstractions;

namespace Domain.Errors;

/// <summary>
/// Clase principal de Errores de dominio.
/// </summary>
public static partial class Errors
{
    /// <summary>
    /// Errores espcificos de escenarios.
    /// </summary>
    public static class ErrorTorneo
    {
        /// <summary>
        /// Indica que se envió un id nulo o inválido.
        /// </summary>
        public static Error InvalidId => Error.NullValue;

        /// <summary>
        /// Indica que un Id proporcionado no fue hallado.
        /// </summary>
        /// <param name="id">Id enviado que no existe.</param>
        /// <returns>Error indicando que no se halló un torneo acorde al Id.</returns>
        public static Error NotFound(string id) => new("Not found", $"Id {id} not found");

        /// <summary>
        /// Indica que el torneo con nombre ya está registrado en la BD para la liga.
        /// </summary>
        /// <param name="nombre">Nombre del torneo.</param>
        /// <param name="liga">Liga del torneo.</param>
        /// <returns>Error indicando que se trató de dar de alta un torneo para la liga en la BD.</returns>
        public static Error Existente(string nombre, string liga) => new("Existente", 
        $"El torneo {nombre} ya existe en la liga {liga}");
    }
}