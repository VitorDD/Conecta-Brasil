using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONECTA_BRASIL.Migrations
{
    /// <inheritdoc />
    public partial class ClassesCorrigidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interesse",
                table: "Pessoa");

            migrationBuilder.AddColumn<string>(
                name: "Conteudo",
                table: "Publicacao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conteudo",
                table: "Publicacao");

            migrationBuilder.AddColumn<int>(
                name: "Interesse",
                table: "Pessoa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
