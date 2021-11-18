using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazonia.DAL.Migrations
{
    public partial class complemento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Idioma = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormatoFicheiro = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DuracaoEmMinutos = table.Column<int>(type: "int", nullable: true),
                    TamanhoEmMB = table.Column<int>(type: "int", nullable: true),
                    LivroDigital_FormatoFicheiro = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    InformacoesLicenca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeDePaginas = table.Column<int>(type: "int", nullable: true),
                    Largura = table.Column<float>(type: "real", nullable: true),
                    Altura = table.Column<float>(type: "real", nullable: true),
                    Profundidade = table.Column<float>(type: "real", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            

            

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Moradas");
        }
    }
}
