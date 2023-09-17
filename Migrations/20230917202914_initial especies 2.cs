using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicios.Migrations
{
    /// <inheritdoc />
    public partial class initialespecies2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspecieRemedio_Especie_EspeciesEspecieId",
                table: "EspecieRemedio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especie",
                table: "Especie");

            migrationBuilder.RenameTable(
                name: "Especie",
                newName: "Especiess");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especiess",
                table: "Especiess",
                column: "EspecieId");

            migrationBuilder.AddForeignKey(
                name: "FK_EspecieRemedio_Especiess_EspeciesEspecieId",
                table: "EspecieRemedio",
                column: "EspeciesEspecieId",
                principalTable: "Especiess",
                principalColumn: "EspecieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspecieRemedio_Especiess_EspeciesEspecieId",
                table: "EspecieRemedio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especiess",
                table: "Especiess");

            migrationBuilder.RenameTable(
                name: "Especiess",
                newName: "Especie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especie",
                table: "Especie",
                column: "EspecieId");

            migrationBuilder.AddForeignKey(
                name: "FK_EspecieRemedio_Especie_EspeciesEspecieId",
                table: "EspecieRemedio",
                column: "EspeciesEspecieId",
                principalTable: "Especie",
                principalColumn: "EspecieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
