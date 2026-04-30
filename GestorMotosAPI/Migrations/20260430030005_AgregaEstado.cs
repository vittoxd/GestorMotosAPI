using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorMotosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregaEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "OrdenesTrabajo",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "OrdenesTrabajo");
        }
    }
}
