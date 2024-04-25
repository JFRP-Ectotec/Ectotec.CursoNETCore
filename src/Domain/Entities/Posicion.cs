using Domain.Abstractions;

namespace Domain.Entities;

public class Posicion : Entity<EquipoTor>
{
    /*
    * Constructor principal
    */

    private Posicion(
        EquipoTor id,
        int ganados,
        int perdidos,
        int empates,
        int puntos,
        int? scoreFavor,
        int? scoreContra)
        : base(id)
    {
        Ganados = ganados;
        Perdidos = perdidos;
        Empates = empates;
        Puntos = puntos;
        ScoreFavor = scoreFavor;
        ScoreContra = scoreContra;
        Porcentaje = (float)(ganados + (empates / 2)) / (ganados + perdidos + empates);
    }

    /*
    * Constructor for EFCore
    */
    #pragma warning disable CS8618
    private Posicion()
    {
    }
    #pragma warning restore CS8618

    /*
    * Propiedades
    */

    public int Ganados { get; private set; } = 0;

    public int Perdidos { get; private set; } = 0;

    public int Empates { get; private set; } = 0;

    public int Puntos { get; private set; } = 0;

    public float Porcentaje { get; private set; } = 0;

    public int? ScoreFavor { get; private set; }

    public int? ScoreContra { get; private set; }

    /*
    * Exponer constructor
    */

    public static Posicion Create(
        string Liga,
        string Torneo,
        string Etapa,
        string Grupo,
        string Club,
        int Ganados,
        int Perdidos,
        int Empates,
        int? ScoreFavor,
        int? ScoreContra)
    {
        var posicion = new Posicion(
            id: new EquipoTor(Liga, Torneo, Etapa, Grupo, Club),
            ganados: Ganados,
            perdidos: Perdidos,
            empates: Empates,
            puntos: (Ganados * 3) + Empates,
            scoreFavor: ScoreFavor ?? 0,
            scoreContra: ScoreContra ?? 0);

        return posicion;
    }
}