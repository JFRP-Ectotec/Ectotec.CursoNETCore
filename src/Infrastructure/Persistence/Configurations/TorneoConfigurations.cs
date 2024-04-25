using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class TorneoConfigurations : IEntityTypeConfiguration<Torneo>
{
    public void Configure(EntityTypeBuilder<Torneo> builder)
    {
        ConfigureTorneoTable(builder);
        ConfigurePosicionTable(builder);
    }

private static void ConfigurePosicionTable(EntityTypeBuilder<Torneo> builder)
    {
        builder.OwnsMany
        (
            m => m.Posiciones,
            d => {
                d.ToTable("posicion");

                d.WithOwner().HasForeignKey("torneo_id")
                    .HasConstraintName("FK_posicion_torneo")
                ;

                d.OwnsOne(
                    m2 => m2.Id,
                    d2 =>
                    {
                        d2.Property(e => e.Liga)
                            .HasColumnName("liga")
                            .IsRequired()
                            .HasMaxLength(20)
                            .HasComment("Liga")
                        ;

                        d2.Property(e => e.Torneo)
                            .HasColumnName("torneo")
                            .IsRequired()
                            .HasMaxLength(50)
                            .HasComment("torneo")
                        ;

                        d2.Property(e => e.Etapa)
                            .HasColumnName("etapa")
                            .IsRequired()
                            .HasMaxLength(20)
                            .HasComment("etapa")
                        ;

                        d2.Property(e => e.Grupo)
                            .HasColumnName("grupo")
                            .IsRequired()
                            .HasMaxLength(20)
                            .HasComment("grupo")
                        ;

                        d2.Property(e => e.Club)
                            .HasColumnName("club")
                            .IsRequired()
                            .HasMaxLength(50)
                            .HasComment("club")
                        ;
                    }
                );

                d.Property(s => s.Ganados)
                    .HasColumnName("ganados")
                    .HasDefaultValue(0)
                    .HasComment("Ganados.");

                d.Property(s => s.Perdidos)
                    .HasColumnName("perdidos")
                    .HasDefaultValue(0)
                    .HasComment("Perdidos.");

                d.Property(s => s.Empates)
                    .HasColumnName("empates")
                    .HasDefaultValue(0)
                    .HasComment("Empates.");

                d.Property(s => s.Porcentaje)
                    .HasColumnName("porcentaje")
                    .HasDefaultValue(0)
                    .HasComment("Porccentaje.");

                d.Property(s => s.Puntos)
                    .HasColumnName("puntos")
                    .HasDefaultValue(0)
                    .HasComment("Puntos obtenidos.");

                d.Property(s => s.ScoreFavor)
                    .HasColumnName("scoreFavor")
                    .HasDefaultValue(0)
                    .HasComment("Score a favor obtenido.");

                d.Property(s => s.ScoreContra)
                    .HasColumnName("scoreContra")
                    .HasDefaultValue(0)
                    .HasComment("Score en contra obtenido.");
            }
        );

        builder.Metadata.FindNavigation(nameof(Torneo.Posiciones))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }


    private static void ConfigureTorneoTable(EntityTypeBuilder<Torneo> builder)
    {
        builder.ToTable("torneo");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever()
            .HasComment("Identificador del registro.")
        ;

        builder.Property(t => t.Nombre)
            .HasColumnName("nombre")
            .IsRequired()
            .HasMaxLength(Torneo.MaxLengthNombre)
            .HasComment("Nombre del torneo.")
        ;

        builder.Property(t => t.Liga)
            .HasColumnName("liga")
            .IsRequired()
            .HasMaxLength(Torneo.MaxLengthLiga)
            .HasComment("Liga del torneo.")
        ;

        builder.Property(t => t.Comentarios)
            .HasColumnName("comentarios")
            .HasMaxLength(Torneo.MaxLengthComentarios)
            .HasComment("Comentarios relevantes al torneo.")
        ;

        builder.Navigation(st => st.Posiciones).Metadata.SetField("_posiciones");
        builder.Navigation(st => st.Posiciones).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
