using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtezaStudio.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarUsuarioSeguidor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarioSeguidores",
                columns: table => new
                {
                    SeguidorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SeguidoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataSeguimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UsuarioId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioSeguidores", x => new { x.SeguidorId, x.SeguidoId });
                    table.ForeignKey(
                        name: "FK_usuarioSeguidores_usuarios_SeguidoId",
                        column: x => x.SeguidoId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuarioSeguidores_usuarios_SeguidorId",
                        column: x => x.SeguidorId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuarioSeguidores_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_usuarioSeguidores_usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioSeguidores_SeguidoId",
                table: "usuarioSeguidores",
                column: "SeguidoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioSeguidores_UsuarioId",
                table: "usuarioSeguidores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioSeguidores_UsuarioId1",
                table: "usuarioSeguidores",
                column: "UsuarioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarioSeguidores");
        }
    }
}
