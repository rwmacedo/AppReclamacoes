using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppReclamacoes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProdutosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Produto",
                table: "Reclamacoes",
                newName: "ProdutoId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Reclamacoes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reclamacoes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CpfCnpj",
                table: "Reclamacoes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeProduto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "NomeProduto" },
                values: new object[,]
                {
                    { 1, "Conta Depósito" },
                    { 2, "Câmbio" },
                    { 3, "Habitação" },
                    { 4, "Penhor" },
                    { 5, "Ações Online" },
                    { 6, "Seguro" },
                    { 7, "Cartão de Crédito" },
                    { 8, "Fundos de Investimento" },
                    { 9, "Consignado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacoes_ProdutoId",
                table: "Reclamacoes",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacoes_Produtos_ProdutoId",
                table: "Reclamacoes",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacoes_Produtos_ProdutoId",
                table: "Reclamacoes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamacoes_ProdutoId",
                table: "Reclamacoes");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Reclamacoes",
                newName: "Produto");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Reclamacoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reclamacoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CpfCnpj",
                table: "Reclamacoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
