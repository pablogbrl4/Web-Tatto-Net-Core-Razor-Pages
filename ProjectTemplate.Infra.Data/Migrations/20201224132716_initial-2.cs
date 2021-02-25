using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTemplate.Infra.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDeCliente",
                table: "Tatuador");

            migrationBuilder.DropColumn(
                name: "NomeDeCliente",
                table: "Estudio");

            migrationBuilder.AddColumn<string>(
                name: "NomeDeUsuario",
                table: "Tatuador",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDeUsuario",
                table: "Estudio",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDeUsuario",
                table: "Tatuador");

            migrationBuilder.DropColumn(
                name: "NomeDeUsuario",
                table: "Estudio");

            migrationBuilder.AddColumn<string>(
                name: "NomeDeCliente",
                table: "Tatuador",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDeCliente",
                table: "Estudio",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
