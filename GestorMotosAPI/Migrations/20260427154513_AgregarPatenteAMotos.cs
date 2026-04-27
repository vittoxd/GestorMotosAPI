using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorMotosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPatenteAMotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Patente",
                table: "Motos",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patente",
                table: "Motos");
        }
    }
}
