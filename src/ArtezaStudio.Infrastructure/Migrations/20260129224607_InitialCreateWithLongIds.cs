using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtezaStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithLongIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImagemPerfilUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAtivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Publicacoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagemUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataPublicacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicacoes_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarioSeguidores",
                columns: table => new
                {
                    SeguidorId = table.Column<long>(type: "bigint", nullable: false),
                    SeguidoId = table.Column<long>(type: "bigint", nullable: false),
                    DataSeguimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: true),
                    UsuarioId1 = table.Column<long>(type: "bigint", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Conteudo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataComentario = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PublicacaoId = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    PublicacaoId1 = table.Column<long>(type: "bigint", nullable: true),
                    UsuarioId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicacoes_PublicacaoId",
                        column: x => x.PublicacaoId,
                        principalTable: "Publicacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicacoes_PublicacaoId1",
                        column: x => x.PublicacaoId1,
                        principalTable: "Publicacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentarios_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Curtidas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCurtida = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PublicacaoId = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    PublicacaoId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curtidas_Publicacoes_PublicacaoId",
                        column: x => x.PublicacaoId,
                        principalTable: "Publicacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curtidas_Publicacoes_PublicacaoId1",
                        column: x => x.PublicacaoId1,
                        principalTable: "Publicacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Curtidas_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicacaoTags",
                columns: table => new
                {
                    PublicacaoId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacaoTags", x => new { x.PublicacaoId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PublicacaoTags_Publicacoes_PublicacaoId",
                        column: x => x.PublicacaoId,
                        principalTable: "Publicacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicacaoTags_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Visualizacoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataVisualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PublicacaoId = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    PublicacaoId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visualizacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visualizacoes_Publicacoes_PublicacaoId",
                        column: x => x.PublicacaoId,
                        principalTable: "Publicacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visualizacoes_Publicacoes_PublicacaoId1",
                        column: x => x.PublicacaoId1,
                        principalTable: "Publicacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visualizacoes_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacaoId",
                table: "Comentarios",
                column: "PublicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacaoId1",
                table: "Comentarios",
                column: "PublicacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioId1",
                table: "Comentarios",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_PublicacaoId",
                table: "Curtidas",
                column: "PublicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_PublicacaoId1",
                table: "Curtidas",
                column: "PublicacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_UsuarioId",
                table: "Curtidas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacaoTags_TagId",
                table: "PublicacaoTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_UsuarioId",
                table: "Publicacoes",
                column: "UsuarioId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Visualizacoes_PublicacaoId",
                table: "Visualizacoes",
                column: "PublicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Visualizacoes_PublicacaoId1",
                table: "Visualizacoes",
                column: "PublicacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Visualizacoes_UsuarioId",
                table: "Visualizacoes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Curtidas");

            migrationBuilder.DropTable(
                name: "PublicacaoTags");

            migrationBuilder.DropTable(
                name: "usuarioSeguidores");

            migrationBuilder.DropTable(
                name: "Visualizacoes");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "Publicacoes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
