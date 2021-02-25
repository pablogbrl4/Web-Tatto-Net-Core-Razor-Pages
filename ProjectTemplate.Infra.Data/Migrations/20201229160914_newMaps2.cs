using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTemplate.Infra.Data.Migrations
{
    public partial class newMaps2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudio_Tatuador",
                table: "Estudio_Tatuador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudio_Tatuador",
                table: "Estudio_Tatuador",
                columns: new[] { "IdEstudio", "IdTatuador" });

            migrationBuilder.CreateIndex(
                name: "IX_Estudio_Tatuador_IdTatuador",
                table: "Estudio_Tatuador",
                column: "IdTatuador");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudio_Tatuador_Estudio_IdEstudio",
                table: "Estudio_Tatuador",
                column: "IdEstudio",
                principalTable: "Estudio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudio_Tatuador_Tatuador_IdTatuador",
                table: "Estudio_Tatuador",
                column: "IdTatuador",
                principalTable: "Tatuador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudio_Tatuador_Estudio_IdEstudio",
                table: "Estudio_Tatuador");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudio_Tatuador_Tatuador_IdTatuador",
                table: "Estudio_Tatuador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudio_Tatuador",
                table: "Estudio_Tatuador");

            migrationBuilder.DropIndex(
                name: "IX_Estudio_Tatuador_IdTatuador",
                table: "Estudio_Tatuador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudio_Tatuador",
                table: "Estudio_Tatuador",
                column: "Id");
        }
    }
}
