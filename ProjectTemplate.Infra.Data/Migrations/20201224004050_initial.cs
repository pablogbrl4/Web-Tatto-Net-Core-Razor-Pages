using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTemplate.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    PrimeiroNome = table.Column<string>(nullable: true),
                    SobrenomeCompleto = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    OutroTelefone = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    DataDeNascimento = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudio = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depoimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudio = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    NomeCliente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depoimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudio = table.Column<int>(nullable: false),
                    NomeDeCliente = table.Column<string>(nullable: true),
                    NomeEstudio = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    OutroTelefone = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    DatadeFundação = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    LinkedIn = table.Column<string>(nullable: true),
                    YouTube = table.Column<string>(nullable: true),
                    WhatsApp = table.Column<string>(nullable: true),
                    TextoBibliografico = table.Column<string>(nullable: true),
                    FraseImpactante = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudio_Tatuador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudio = table.Column<int>(nullable: false),
                    IdTatuador = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudio_Tatuador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FotosEstudio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudio = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosEstudio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tatuador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTatuador = table.Column<int>(nullable: false),
                    NomeDeCliente = table.Column<string>(nullable: true),
                    PrimeiroNome = table.Column<string>(nullable: true),
                    SobrenomeCompleto = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    LinkedIn = table.Column<string>(nullable: true),
                    YouTube = table.Column<string>(nullable: true),
                    WhatsApp = table.Column<string>(nullable: true),
                    TextoBibliografico = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    OutroTelefone = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    DataDeNascimento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tatuador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HorarioDeFuncionamentoEstudio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudio = table.Column<int>(nullable: false),
                    DiaSemana = table.Column<string>(nullable: true),
                    Abertura = table.Column<string>(nullable: true),
                    Fechamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioDeFuncionamentoEstudio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioDeFuncionamentoEstudio_Estudio_IdEstudio",
                        column: x => x.IdEstudio,
                        principalTable: "Estudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shopping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudio = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    Categoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shopping_Estudio_IdEstudio",
                        column: x => x.IdEstudio,
                        principalTable: "Estudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    IdEstudio = table.Column<int>(nullable: false),
                    IdTatuador = table.Column<int>(nullable: false),
                    DataMarcação = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Alergia = table.Column<bool>(nullable: false),
                    TextoAlergia = table.Column<string>(nullable: true),
                    Hepatite = table.Column<bool>(nullable: false),
                    TextoHepatite = table.Column<string>(nullable: true),
                    DST = table.Column<bool>(nullable: false),
                    TextoDST = table.Column<string>(nullable: true),
                    UtilizaMedicamento = table.Column<bool>(nullable: false),
                    TextoUtilizaMedicamento = table.Column<string>(nullable: true),
                    problemaDermatológico = table.Column<bool>(nullable: false),
                    TextoproblemaDermatológico = table.Column<string>(nullable: true),
                    Epilepsia = table.Column<bool>(nullable: false),
                    TextoEpilepsia = table.Column<string>(nullable: true),
                    ProblemaCardiaco = table.Column<bool>(nullable: false),
                    TextoProblemaCardiaco = table.Column<string>(nullable: true),
                    UsaDrogas = table.Column<bool>(nullable: false),
                    TextoUsaDrogas = table.Column<string>(nullable: true),
                    TipoSanguineo = table.Column<string>(nullable: true),
                    AlimentouBem = table.Column<bool>(nullable: false),
                    Gravida = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Estudio_IdEstudio",
                        column: x => x.IdEstudio,
                        principalTable: "Estudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Tatuador_IdTatuador",
                        column: x => x.IdTatuador,
                        principalTable: "Tatuador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotoTatto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudio = table.Column<int>(nullable: false),
                    IdTatuador = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    EstiloTatto = table.Column<string>(nullable: true),
                    ParteDoCorpo = table.Column<string>(nullable: true),
                    Genero = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoTatto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotoTatto_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FotoTatto_Estudio_IdEstudio",
                        column: x => x.IdEstudio,
                        principalTable: "Estudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FotoTatto_Tatuador_IdTatuador",
                        column: x => x.IdTatuador,
                        principalTable: "Tatuador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdCliente",
                table: "Agenda",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdEstudio",
                table: "Agenda",
                column: "IdEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdTatuador",
                table: "Agenda",
                column: "IdTatuador");

            migrationBuilder.CreateIndex(
                name: "IX_FotoTatto_IdCliente",
                table: "FotoTatto",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_FotoTatto_IdEstudio",
                table: "FotoTatto",
                column: "IdEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_FotoTatto_IdTatuador",
                table: "FotoTatto",
                column: "IdTatuador");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDeFuncionamentoEstudio_IdEstudio",
                table: "HorarioDeFuncionamentoEstudio",
                column: "IdEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_IdEstudio",
                table: "Shopping",
                column: "IdEstudio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Depoimentos");

            migrationBuilder.DropTable(
                name: "Estudio_Tatuador");

            migrationBuilder.DropTable(
                name: "FotosEstudio");

            migrationBuilder.DropTable(
                name: "FotoTatto");

            migrationBuilder.DropTable(
                name: "HorarioDeFuncionamentoEstudio");

            migrationBuilder.DropTable(
                name: "Shopping");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Tatuador");

            migrationBuilder.DropTable(
                name: "Estudio");
        }
    }
}
