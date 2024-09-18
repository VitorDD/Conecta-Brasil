using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONECTA_BRASIL.Migrations
{
    /// <inheritdoc />
    public partial class HomeViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_PagInicial_PagInicialId",
                table: "Publicacoes");

            migrationBuilder.DropTable(
                name: "PagInicial");

            migrationBuilder.DropIndex(
                name: "IX_Publicacoes_PagInicialId",
                table: "Publicacoes");

            migrationBuilder.DropColumn(
                name: "PagInicialId",
                table: "Publicacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PagInicialId",
                table: "Publicacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PagInicial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagInicial", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_PagInicialId",
                table: "Publicacoes",
                column: "PagInicialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_PagInicial_PagInicialId",
                table: "Publicacoes",
                column: "PagInicialId",
                principalTable: "PagInicial",
                principalColumn: "Id");
        }
    }
}
