using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicios.Migrations
{
    /// <inheritdoc />
    public partial class initialespecies3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RemedioId",
                table: "Especiess",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemedioId",
                table: "Especiess");
        }
    }
}
