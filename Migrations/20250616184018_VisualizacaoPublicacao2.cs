using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtezaStudio.Api.Migrations
{
    /// <inheritdoc />
    public partial class VisualizacaoPublicacao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublicacaoId1",
                table: "visualizacoes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_visualizacoes_PublicacaoId1",
                table: "visualizacoes",
                column: "PublicacaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_visualizacoes_publicacoes_PublicacaoId1",
                table: "visualizacoes",
                column: "PublicacaoId1",
                principalTable: "publicacoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visualizacoes_publicacoes_PublicacaoId1",
                table: "visualizacoes");

            migrationBuilder.DropIndex(
                name: "IX_visualizacoes_PublicacaoId1",
                table: "visualizacoes");

            migrationBuilder.DropColumn(
                name: "PublicacaoId1",
                table: "visualizacoes");
        }
    }
}
