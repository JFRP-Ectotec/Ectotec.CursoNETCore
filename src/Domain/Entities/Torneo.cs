using System.Collections.ObjectModel;
using Domain.Abstractions;

namespace Domain.Entities;

public sealed class Torneo : Entity<Guid>
{
    /*
    * Constantes de validación
    */

    /// <summary>
    /// Longitud máxima de la liga.
    /// </summary>
    public const int MaxLengthLiga = 10;

    /// <summary>
    /// Longitud máxima del nombre del torneo.
    /// </summary>
    public const int MaxLengthNombre = 30;

    /// <summary>
    /// Longitud máxima del comentario.
    /// </summary>
    public const int MaxLengthComentarios = 1000;

    /*
    * Colecciones hijas
    */

    private readonly List<Posicion> _posiciones = [];

    /*
    * Constructor principal
    */

    private Torneo(
        Guid id,
        string nombre,
        string liga,
        string comentarios)
        : base(id)
    {
        Nombre = nombre;
        Liga = liga;
        Comentarios = comentarios;
    }

    /*
    * Constructor for EFCore
    */
    private Torneo()
    {
    }

    /*
    * Propiedades
    */

    /// <summary>
    /// Liga a la que aplica el escenario.
    /// </summary>
    /// <value>String con la Liga a la que aplica el escenario.</value>
    public string Liga { get; private set; } = string.Empty;

    /// <summary>
    /// Nombre del torneo.
    /// </summary>
    public string Nombre { get; private set; } = string.Empty;

    /// <summary>
    /// Comentarios relevantes al torneo.
    /// </summary>
    public string Comentarios { get; private set; } = string.Empty;

    /*
    * Exponer colecciones hijas
    */

    /// <summary>
    /// Escenarios asociados al Torneo.
    /// </summary>
    /// <returns>Listado de escenarios en un torneo.</returns>
    public IReadOnlyCollection<Posicion> Posiciones => _posiciones;


    /*
    * Exponer constructor
    */

    /// <summary>
    /// Constructor de la clase.
    /// </summary>
    /// <param name="nombre">Nombre del escenario.</param>
    /// <param name="liga">Liga deportiva a la que aplica.</param>
    /// <param name="comentarios">Comentarios referentes al torneo.</param>
    /// <returns>Objeto Escenario.</returns>
    public static Torneo Create(
        string nombre,
        string liga,
        string? comentarios = "")
    {
        var torneo = new Torneo(
            Guid.NewGuid(),
            nombre,
            liga,
            comentarios ?? string.Empty);

        return torneo;
    }

    /*
    * Métodos para lidiar con colecciones hijas
    */

    /// <summary>
    /// Agregar un escenario ya construido al torneo.
    /// </summary>
    /// <param name="escenario">Escenario a agregar.</param>
    public void AddPosicion(
        Posicion posicion)
    {
        _posiciones.Add(posicion);
    }

    /// <summary>
    /// Agrega un escenario al torneo en base a sus componentes.
    /// </summary>
    /// <param name="nombre">Nombre del equipo.</param>
    /// <param name="etapas">Escenarios en el torneo.</param>
    /// <param name="original">Si el escenario es original.</param>
    /// <param name="comentarios">Comentarios relevantes al escenario.</param>
    public void AddPosicion(
        string liga,
        string torneo,
        string etapa,
        string grupo,
        string club,
        int ganados,
        int perdidos,
        int empates,
        int? scoreFavor = 0,
        int? scoreContra = 0)
    {
        var posicion = Posicion.Create(
            liga,
            torneo,
            etapa,
            grupo,
            club,
            ganados,
            perdidos,
            empates,
            scoreFavor,
            scoreContra);
        AddPosicion(posicion);
    }

    /// <summary>
    /// Asignar un conjunto de escenarios al torneo.
    /// </summary>
    /// <param name="escenarios">Escenarios a agregar.</param>
    public void SetPosiciones(ReadOnlyCollection<Posicion> posiciones)
    {
        ClearPosiciones();
        posiciones.ToList().ForEach(
            p =>
            {
                AddPosicion(p);
            }
        );
    }

    /// <summary>
    /// Limpiar la colección de escenarios.
    /// </summary>
    public void ClearPosiciones()
    {
        _posiciones.Clear();
    }

    /// <summary>
    /// Quitar un escenario del torneo.
    /// </summary>
    /// <param name="escenario">escenario a quitar.</param>
    public void RemovePosicion(Posicion posicion)
    {
        _posiciones.Remove(posicion);
    }

    /// <summary>
    /// Quitar un conjunto de escenarios.
    /// </summary>
    /// <param name="escenarios">escenarios a quitar.</param>
    public void RemovePosiciones(ReadOnlyCollection<Posicion> posiciones)
    {
        posiciones.ToList().ForEach(RemovePosicion);
    }
}