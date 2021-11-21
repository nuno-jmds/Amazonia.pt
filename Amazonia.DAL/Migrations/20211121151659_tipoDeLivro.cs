using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazonia.DAL.Migrations
{
    public partial class tipoDeLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoDeLivro",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDeLivro",
                table: "Livros");
        }
    }
}
