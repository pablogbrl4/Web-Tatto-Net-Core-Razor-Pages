using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTemplate.Infra.Data.Migrations
{
    public partial class newMaps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos");

            migrationBuilder.AlterColumn<string>(
                name: "NomeDeUsuario",
                table: "Tatuador",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tatuador",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Tatuador",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeDeUsuario",
                table: "Estudio",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Estudio",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Estudio",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos",
                columns: new[] { "IdEstudio", "IdCliente" });

            migrationBuilder.CreateIndex(
                name: "IX_Tatuador_CPF",
                table: "Tatuador",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tatuador_Email",
                table: "Tatuador",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tatuador_NomeDeUsuario",
                table: "Tatuador",
                column: "NomeDeUsuario",
                unique: true,
                filter: "[NomeDeUsuario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Estudio_CNPJ",
                table: "Estudio",
                column: "CNPJ",
                unique: true,
                filter: "[CNPJ] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Estudio_Email",
                table: "Estudio",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Estudio_NomeDeUsuario",
                table: "Estudio",
                column: "NomeDeUsuario",
                unique: true,
                filter: "[NomeDeUsuario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_IdCliente",
                table: "Contatos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CPF",
                table: "Cliente",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Email",
                table: "Cliente",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Cliente_IdCliente",
                table: "Contatos",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Estudio_IdEstudio",
                table: "Contatos",
                column: "IdEstudio",
                principalTable: "Estudio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Cliente_IdCliente",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Estudio_IdEstudio",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Tatuador_CPF",
                table: "Tatuador");

            migrationBuilder.DropIndex(
                name: "IX_Tatuador_Email",
                table: "Tatuador");

            migrationBuilder.DropIndex(
                name: "IX_Tatuador_NomeDeUsuario",
                table: "Tatuador");

            migrationBuilder.DropIndex(
                name: "IX_Estudio_CNPJ",
                table: "Estudio");

            migrationBuilder.DropIndex(
                name: "IX_Estudio_Email",
                table: "Estudio");

            migrationBuilder.DropIndex(
                name: "IX_Estudio_NomeDeUsuario",
                table: "Estudio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_IdCliente",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_CPF",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Email",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "NomeDeUsuario",
                table: "Tatuador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tatuador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Tatuador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeDeUsuario",
                table: "Estudio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Estudio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Estudio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos",
                column: "Id");
        }
    }
}
