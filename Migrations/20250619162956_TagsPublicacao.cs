using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtezaStudio.Api.Migrations
{
    /// <inheritdoc />
    public partial class TagsPublicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_publicacoes_PublicacaoId",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_publicacoes_PublicacaoId1",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_usuarios_UsuarioId",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_comentarios_usuarios_UsuarioId1",
                table: "comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_curtidas_publicacoes_PublicacaoId",
                table: "curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_curtidas_publicacoes_PublicacaoId1",
                table: "curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_curtidas_usuarios_UsuarioId",
                table: "curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_publicacoes_usuarios_UsuarioId",
                table: "publicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_visualizacoes_publicacoes_PublicacaoId",
                table: "visualizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_visualizacoes_publicacoes_PublicacaoId1",
                table: "visualizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_visualizacoes_usuarios_UsuarioId",
                table: "visualizacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_visualizacoes",
                table: "visualizacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_publicacoes",
                table: "publicacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_curtidas",
                table: "curtidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comentarios",
                table: "comentarios");

            migrationBuilder.RenameTable(
                name: "visualizacoes",
                newName: "Visualizacoes");

            migrationBuilder.RenameTable(
                name: "publicacoes",
                newName: "Publicacoes");

            migrationBuilder.RenameTable(
                name: "curtidas",
                newName: "Curtidas");

            migrationBuilder.RenameTable(
                name: "comentarios",
                newName: "Comentarios");

            migrationBuilder.RenameIndex(
                name: "IX_visualizacoes_UsuarioId",
                table: "Visualizacoes",
                newName: "IX_Visualizacoes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_visualizacoes_PublicacaoId1",
                table: "Visualizacoes",
                newName: "IX_Visualizacoes_PublicacaoId1");

            migrationBuilder.RenameIndex(
                name: "IX_visualizacoes_PublicacaoId",
                table: "Visualizacoes",
                newName: "IX_Visualizacoes_PublicacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_publicacoes_UsuarioId",
                table: "Publicacoes",
                newName: "IX_Publicacoes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_curtidas_UsuarioId",
                table: "Curtidas",
                newName: "IX_Curtidas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_curtidas_PublicacaoId1",
                table: "Curtidas",
                newName: "IX_Curtidas_PublicacaoId1");

            migrationBuilder.RenameIndex(
                name: "IX_curtidas_PublicacaoId",
                table: "Curtidas",
                newName: "IX_Curtidas_PublicacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_comentarios_UsuarioId1",
                table: "Comentarios",
                newName: "IX_Comentarios_UsuarioId1");

            migrationBuilder.RenameIndex(
                name: "IX_comentarios_UsuarioId",
                table: "Comentarios",
                newName: "IX_Comentarios_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_comentarios_PublicacaoId1",
                table: "Comentarios",
                newName: "IX_Comentarios_PublicacaoId1");

            migrationBuilder.RenameIndex(
                name: "IX_comentarios_PublicacaoId",
                table: "Comentarios",
                newName: "IX_Comentarios_PublicacaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visualizacoes",
                table: "Visualizacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicacoes",
                table: "Publicacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curtidas",
                table: "Curtidas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicacaoTags",
                columns: table => new
                {
                    PublicacaoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TagId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
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

            migrationBuilder.CreateIndex(
                name: "IX_PublicacaoTags_TagId",
                table: "PublicacaoTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacoes_PublicacaoId",
                table: "Comentarios",
                column: "PublicacaoId",
                principalTable: "Publicacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacoes_PublicacaoId1",
                table: "Comentarios",
                column: "PublicacaoId1",
                principalTable: "Publicacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_usuarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_usuarios_UsuarioId1",
                table: "Comentarios",
                column: "UsuarioId1",
                principalTable: "usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Publicacoes_PublicacaoId",
                table: "Curtidas",
                column: "PublicacaoId",
                principalTable: "Publicacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Publicacoes_PublicacaoId1",
                table: "Curtidas",
                column: "PublicacaoId1",
                principalTable: "Publicacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_usuarios_UsuarioId",
                table: "Curtidas",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_usuarios_UsuarioId",
                table: "Publicacoes",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visualizacoes_Publicacoes_PublicacaoId",
                table: "Visualizacoes",
                column: "PublicacaoId",
                principalTable: "Publicacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visualizacoes_Publicacoes_PublicacaoId1",
                table: "Visualizacoes",
                column: "PublicacaoId1",
                principalTable: "Publicacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visualizacoes_usuarios_UsuarioId",
                table: "Visualizacoes",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicacoes_PublicacaoId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicacoes_PublicacaoId1",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_usuarios_UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_usuarios_UsuarioId1",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Publicacoes_PublicacaoId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Publicacoes_PublicacaoId1",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_usuarios_UsuarioId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_usuarios_UsuarioId",
                table: "Publicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualizacoes_Publicacoes_PublicacaoId",
                table: "Visualizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualizacoes_Publicacoes_PublicacaoId1",
                table: "Visualizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Visualizacoes_usuarios_UsuarioId",
                table: "Visualizacoes");

            migrationBuilder.DropTable(
                name: "PublicacaoTags");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visualizacoes",
                table: "Visualizacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicacoes",
                table: "Publicacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curtidas",
                table: "Curtidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios");

            migrationBuilder.RenameTable(
                name: "Visualizacoes",
                newName: "visualizacoes");

            migrationBuilder.RenameTable(
                name: "Publicacoes",
                newName: "publicacoes");

            migrationBuilder.RenameTable(
                name: "Curtidas",
                newName: "curtidas");

            migrationBuilder.RenameTable(
                name: "Comentarios",
                newName: "comentarios");

            migrationBuilder.RenameIndex(
                name: "IX_Visualizacoes_UsuarioId",
                table: "visualizacoes",
                newName: "IX_visualizacoes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Visualizacoes_PublicacaoId1",
                table: "visualizacoes",
                newName: "IX_visualizacoes_PublicacaoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Visualizacoes_PublicacaoId",
                table: "visualizacoes",
                newName: "IX_visualizacoes_PublicacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacoes_UsuarioId",
                table: "publicacoes",
                newName: "IX_publicacoes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_UsuarioId",
                table: "curtidas",
                newName: "IX_curtidas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_PublicacaoId1",
                table: "curtidas",
                newName: "IX_curtidas_PublicacaoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_PublicacaoId",
                table: "curtidas",
                newName: "IX_curtidas_PublicacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_UsuarioId1",
                table: "comentarios",
                newName: "IX_comentarios_UsuarioId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "comentarios",
                newName: "IX_comentarios_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_PublicacaoId1",
                table: "comentarios",
                newName: "IX_comentarios_PublicacaoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_PublicacaoId",
                table: "comentarios",
                newName: "IX_comentarios_PublicacaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_visualizacoes",
                table: "visualizacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_publicacoes",
                table: "publicacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_curtidas",
                table: "curtidas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comentarios",
                table: "comentarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_publicacoes_PublicacaoId",
                table: "comentarios",
                column: "PublicacaoId",
                principalTable: "publicacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_publicacoes_PublicacaoId1",
                table: "comentarios",
                column: "PublicacaoId1",
                principalTable: "publicacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_usuarios_UsuarioId",
                table: "comentarios",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comentarios_usuarios_UsuarioId1",
                table: "comentarios",
                column: "UsuarioId1",
                principalTable: "usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_curtidas_publicacoes_PublicacaoId",
                table: "curtidas",
                column: "PublicacaoId",
                principalTable: "publicacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_curtidas_publicacoes_PublicacaoId1",
                table: "curtidas",
                column: "PublicacaoId1",
                principalTable: "publicacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_curtidas_usuarios_UsuarioId",
                table: "curtidas",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_publicacoes_usuarios_UsuarioId",
                table: "publicacoes",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visualizacoes_publicacoes_PublicacaoId",
                table: "visualizacoes",
                column: "PublicacaoId",
                principalTable: "publicacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visualizacoes_publicacoes_PublicacaoId1",
                table: "visualizacoes",
                column: "PublicacaoId1",
                principalTable: "publicacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_visualizacoes_usuarios_UsuarioId",
                table: "visualizacoes",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
