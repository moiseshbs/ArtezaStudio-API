using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtezaStudio.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjusteComentarioRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublicacaoId1",
                table: "comentarios",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId1",
                table: "comentarios",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_PublicacaoId1",
                table: "comentarios",
                column: "PublicacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_UsuarioId1",
                table: "comentarios",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_publicacoes_PublicacaoId1",
                table: "comentarios",
                column: "PublicacaoId1",
                principalTable: "publicacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_usuarios_UsuarioId1",
                table: "comentarios",
                column: "UsuarioId1",
                principalTable: "usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_publicacoes_PublicacaoId1",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_usuarios_UsuarioId1",
                table: "comentarios");

            migrationBuilder.DropIndex(
                name: "IX_comentarios_PublicacaoId1",
                table: "comentarios");

            migrationBuilder.DropIndex(
                name: "IX_comentarios_UsuarioId1",
                table: "comentarios");

            migrationBuilder.DropColumn(
                name: "PublicacaoId1",
                table: "comentarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "comentarios");
        }
    }
}
