﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTemplate.Infra.Data.Contexto;

namespace ProjectTemplate.Infra.Data.Migrations
{
    [DbContext(typeof(BaseContexto))]
    [Migration("20201224004050_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Alergia")
                        .HasColumnType("bit");

                    b.Property<bool>("AlimentouBem")
                        .HasColumnType("bit");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<bool>("DST")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataMarcação")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Epilepsia")
                        .HasColumnType("bit");

                    b.Property<bool>("Gravida")
                        .HasColumnType("bit");

                    b.Property<bool>("Hepatite")
                        .HasColumnType("bit");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudio")
                        .HasColumnType("int");

                    b.Property<int>("IdTatuador")
                        .HasColumnType("int");

                    b.Property<bool>("ProblemaCardiaco")
                        .HasColumnType("bit");

                    b.Property<string>("TextoAlergia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoDST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoEpilepsia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoHepatite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoProblemaCardiaco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoUsaDrogas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoUtilizaMedicamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoproblemaDermatológico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoSanguineo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UsaDrogas")
                        .HasColumnType("bit");

                    b.Property<bool>("UtilizaMedicamento")
                        .HasColumnType("bit");

                    b.Property<bool>("problemaDermatológico")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEstudio");

                    b.HasIndex("IdTatuador");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataDeNascimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutroTelefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobrenomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Contatos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Depoimentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudio")
                        .HasColumnType("int");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Depoimentos");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Estudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DatadeFundação")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FraseImpactante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEstudio")
                        .HasColumnType("int");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDeCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEstudio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutroTelefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoBibliografico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatsApp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YouTube")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estudio");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Estudio_Tatuador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEstudio")
                        .HasColumnType("int");

                    b.Property<int>("IdTatuador")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Estudio_Tatuador");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.FotoTatto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstiloTatto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudio")
                        .HasColumnType("int");

                    b.Property<int>("IdTatuador")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParteDoCorpo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEstudio");

                    b.HasIndex("IdTatuador");

                    b.ToTable("FotoTatto");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.FotosEstudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEstudio")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FotosEstudio");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.HorarioDeFuncionamentoEstudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abertura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaSemana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fechamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEstudio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEstudio");

                    b.ToTable("HorarioDeFuncionamentoEstudio");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Shopping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEstudio")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstudio");

                    b.ToTable("Shopping");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Tatuador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataDeNascimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTatuador")
                        .HasColumnType("int");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDeCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutroTelefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobrenomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoBibliografico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatsApp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YouTube")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tatuador");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Agenda", b =>
                {
                    b.HasOne("ProjectTemplate.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Agenda")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTemplate.Domain.Entities.Estudio", "Estudio")
                        .WithMany("Agenda")
                        .HasForeignKey("IdEstudio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTemplate.Domain.Entities.Tatuador", "Tatuador")
                        .WithMany("Agenda")
                        .HasForeignKey("IdTatuador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.FotoTatto", b =>
                {
                    b.HasOne("ProjectTemplate.Domain.Entities.Cliente", "Cliente")
                        .WithMany("FotoTatto")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTemplate.Domain.Entities.Estudio", "Estudio")
                        .WithMany("FotoTatto")
                        .HasForeignKey("IdEstudio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTemplate.Domain.Entities.Tatuador", "Tatuador")
                        .WithMany("FotoTatto")
                        .HasForeignKey("IdTatuador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.HorarioDeFuncionamentoEstudio", b =>
                {
                    b.HasOne("ProjectTemplate.Domain.Entities.Estudio", "Estudio")
                        .WithMany("HorarioDeFuncionamentoEstudio")
                        .HasForeignKey("IdEstudio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTemplate.Domain.Entities.Shopping", b =>
                {
                    b.HasOne("ProjectTemplate.Domain.Entities.Estudio", "Estudio")
                        .WithMany("Shopping")
                        .HasForeignKey("IdEstudio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
