using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "torneo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "binary(16)", nullable: false, comment: "Identificador del registro."),
                    liga = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "Liga del torneo.")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "Nombre del torneo.")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    comentarios = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false, comment: "Comentarios relevantes al torneo.")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_torneo", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "posicion",
                columns: table => new
                {
                    torneo_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    Id1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ganados = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Ganados."),
                    perdidos = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Perdidos."),
                    empates = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Empates."),
                    puntos = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Puntos obtenidos."),
                    porcentaje = table.Column<float>(type: "float", nullable: false, defaultValue: 0f, comment: "Porccentaje."),
                    scoreFavor = table.Column<int>(type: "int", nullable: true, defaultValue: 0, comment: "Score a favor obtenido."),
                    scoreContra = table.Column<int>(type: "int", nullable: true, defaultValue: 0, comment: "Score en contra obtenido."),
                    liga = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "Liga")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    torneo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "torneo")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    etapa = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "etapa")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    grupo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "grupo")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    club = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "club")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posicion", x => new { x.torneo_id, x.Id1 });
                    table.ForeignKey(
                        name: "FK_posicion_torneo",
                        column: x => x.torneo_id,
                        principalTable: "torneo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posicion");

            migrationBuilder.DropTable(
                name: "torneo");
        }
    }
}
