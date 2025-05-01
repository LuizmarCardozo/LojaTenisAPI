using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace LojaTenisAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoImagem_Produtos_ProdutoId",
                table: "ProdutoImagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoImagem",
                table: "ProdutoImagem");

            migrationBuilder.RenameTable(
                name: "ProdutoImagem",
                newName: "Imagens");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoImagem_ProdutoId",
                table: "Imagens",
                newName: "IX_Imagens_ProdutoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Imagens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    SenhaHash = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Produtos_ProdutoId",
                table: "Imagens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Produtos_ProdutoId",
                table: "Imagens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens");

            migrationBuilder.RenameTable(
                name: "Imagens",
                newName: "ProdutoImagem");

            migrationBuilder.RenameIndex(
                name: "IX_Imagens_ProdutoId",
                table: "ProdutoImagem",
                newName: "IX_ProdutoImagem_ProdutoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "ProdutoImagem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoImagem",
                table: "ProdutoImagem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoImagem_Produtos_ProdutoId",
                table: "ProdutoImagem",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
