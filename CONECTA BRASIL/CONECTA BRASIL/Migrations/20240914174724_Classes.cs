using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONECTA_BRASIL.Migrations
{
    /// <inheritdoc />
    public partial class Classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Publicacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Publicacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
