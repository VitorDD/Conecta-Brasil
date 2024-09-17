using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONECTA_BRASIL.Migrations
{
    /// <inheritdoc />
    public partial class Classes1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacao_Usuario_CriadorId",
                table: "Publicacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicacao",
                table: "Publicacao");

            migrationBuilder.RenameTable(
                name: "Publicacao",
                newName: "Publicacoes");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacao_CriadorId",
                table: "Publicacoes",
                newName: "IX_Publicacoes_CriadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicacoes",
                table: "Publicacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Usuario_CriadorId",
                table: "Publicacoes",
                column: "CriadorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Usuario_CriadorId",
                table: "Publicacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicacoes",
                table: "Publicacoes");

            migrationBuilder.RenameTable(
                name: "Publicacoes",
                newName: "Publicacao");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacoes_CriadorId",
                table: "Publicacao",
                newName: "IX_Publicacao_CriadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicacao",
                table: "Publicacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacao_Usuario_CriadorId",
                table: "Publicacao",
                column: "CriadorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
