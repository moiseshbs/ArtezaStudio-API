using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtezaStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TornarImagemPerfilOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagemPerfilUrl",
                table: "usuarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "ImagemPerfilUrl",
                keyValue: null,
                column: "ImagemPerfilUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemPerfilUrl",
                table: "usuarios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
