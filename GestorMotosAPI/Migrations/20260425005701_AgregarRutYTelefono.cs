using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorMotosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRutYTelefono : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AniosExperiencia",
                table: "Mecanicos");

            migrationBuilder.AddColumn<string>(
                name: "Rut",
                table: "Mecanicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Mecanicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rut",
                table: "Mecanicos");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Mecanicos");

            migrationBuilder.AddColumn<int>(
                name: "AniosExperiencia",
                table: "Mecanicos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
