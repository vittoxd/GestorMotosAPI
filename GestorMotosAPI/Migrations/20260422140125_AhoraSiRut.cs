using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorMotosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AhoraSiRut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RutDueno",
                table: "Motos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RutDueno",
                table: "Motos");
        }
    }
}
