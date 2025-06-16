using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtezaStudio.Api.Migrations
{
    /// <inheritdoc />
    public partial class CurtidaPublicacao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublicacaoId1",
                table: "curtidas",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_curtidas_PublicacaoId1",
                table: "curtidas",
                column: "PublicacaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_curtidas_publicacoes_PublicacaoId1",
                table: "curtidas",
                column: "PublicacaoId1",
                principalTable: "publicacoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_curtidas_publicacoes_PublicacaoId1",
                table: "curtidas");

            migrationBuilder.DropIndex(
                name: "IX_curtidas_PublicacaoId1",
                table: "curtidas");

            migrationBuilder.DropColumn(
                name: "PublicacaoId1",
                table: "curtidas");
        }
    }
}
