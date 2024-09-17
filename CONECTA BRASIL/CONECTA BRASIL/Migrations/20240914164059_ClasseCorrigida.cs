using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONECTA_BRASIL.Migrations
{
    /// <inheritdoc />
    public partial class ClasseCorrigida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instituição");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "CriadorId",
                table: "Publicacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Usuario",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Atuacao",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuario",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacao_CriadorId",
                table: "Publicacao",
                column: "CriadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacao_Usuario_CriadorId",
                table: "Publicacao",
                column: "CriadorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacao_Usuario_CriadorId",
                table: "Publicacao");

            migrationBuilder.DropIndex(
                name: "IX_Publicacao_CriadorId",
                table: "Publicacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CriadorId",
                table: "Publicacao");

            migrationBuilder.DropColumn(
                name: "Atuacao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Pessoa");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Pessoa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Instituição",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atuacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituição", x => x.Id);
                });
        }
    }
}
