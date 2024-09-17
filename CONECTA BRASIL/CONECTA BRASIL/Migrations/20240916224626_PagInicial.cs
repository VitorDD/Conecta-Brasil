using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONECTA_BRASIL.Migrations
{
    /// <inheritdoc />
    public partial class PagInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PagInicialId",
                table: "Publicacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
            name: "PublicacaoCategorias",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CategoriaId = table.Column<int>(type: "int", nullable: false),
                PublicacaoId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PublicacaoCategorias", x => x.Id);
                table.ForeignKey(
                    name: "FK_PublicacaoCategorias_Categorias_CategoriaId",
                    column: x => x.CategoriaId,
                    principalTable: "Categorias",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_PublicacaoCategorias_Publicacoes_PublicacaoId",
                    column: x => x.PublicacaoId,
                    principalTable: "Publicacoes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_PagInicialId",
                table: "Publicacoes",
                column: "PagInicialId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_UsuarioId",
                table: "Categorias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacaoCategorias_CategoriaId",
                table: "PublicacaoCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacaoCategorias_PublicacaoId",
                table: "PublicacaoCategorias",
                column: "PublicacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_PagInicial_PagInicialId",
                table: "Publicacoes",
                column: "PagInicialId",
                principalTable: "PagInicial",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_PagInicial_PagInicialId",
                table: "Publicacoes");

            migrationBuilder.DropTable(
                name: "PagInicial");

            migrationBuilder.DropTable(
                name: "PublicacaoCategorias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Publicacoes_PagInicialId",
                table: "Publicacoes");

            migrationBuilder.DropColumn(
                name: "PagInicialId",
                table: "Publicacoes");
        }
    }
}
