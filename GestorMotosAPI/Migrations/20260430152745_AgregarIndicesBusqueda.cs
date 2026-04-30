using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorMotosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarIndicesBusqueda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Motos_Patente",
                table: "Motos",
                column: "Patente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motos_RutDueno",
                table: "Motos",
                column: "RutDueno");

            migrationBuilder.CreateIndex(
                name: "IX_Mecanicos_Rut",
                table: "Mecanicos",
                column: "Rut",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Motos_Patente",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Motos_RutDueno",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Mecanicos_Rut",
                table: "Mecanicos");
        }
    }
}
