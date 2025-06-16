using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtezaStudio.Api.Migrations
{
    /// <inheritdoc />
    public partial class VisualizacaoPublicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "visualizacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataVisualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PublicacaoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visualizacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_visualizacoes_publicacoes_PublicacaoId",
                        column: x => x.PublicacaoId,
                        principalTable: "publicacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visualizacoes_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_visualizacoes_PublicacaoId",
                table: "visualizacoes",
                column: "PublicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_visualizacoes_UsuarioId",
                table: "visualizacoes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "visualizacoes");
        }
    }
}
