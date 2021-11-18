﻿// <auto-generated />
using System;
using Amazonia.DAL.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Amazonia.DAL.Migrations
{
    [DbContext(typeof(AmazoniaContexto))]
    partial class AmazoniaContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Amazonia.DAL.Modelo.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MoradaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NumeroIdentificacaoFiscal")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MoradaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Amazonia.DAL.Modelo.Livro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idioma")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Livros");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Livro");
                });

            modelBuilder.Entity("Amazonia.DAL.Modelo.Morada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Concelho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distrito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Moradas");
                });

            modelBuilder.Entity("Amazonia.DAL.Modelo.AudioLivro", b =>
                {
                    b.HasBaseType("Amazonia.DAL.Modelo.Livro");

                    b.Property<int?>("DuracaoEmMinutos")
                        .HasColumnType("int");

                    b.Property<string>("FormatoFicheiro")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasDiscriminator().HasValue("AudioLivro");
                });

            modelBuilder.Entity("Amazonia.DAL.Modelo.LivroDigital", b =>
                {
                    b.HasBaseType("Amazonia.DAL.Modelo.Livro");

                    b.Property<string>("FormatoFicheiro")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("LivroDigital_FormatoFicheiro");

                    b.Property<string>("InformacoesLicenca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TamanhoEmMB")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("LivroDigital");
                });

            modelBuilder.Entity("Amazonia.DAL.Modelo.LivroImpresso", b =>
                {
                    b.HasBaseType("Amazonia.DAL.Modelo.Livro");

                    b.Property<float>("Altura")
                        .HasColumnType("real");

                    b.Property<float>("Largura")
                        .HasColumnType("real");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<float>("Profundidade")
                        .HasColumnType("real");

                    b.Property<int>("QuantidadeDePaginas")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("LivroImpresso");
                });

            modelBuilder.Entity("Amazonia.DAL.Modelo.LivroPeriodico", b =>
                {
                    b.HasBaseType("Amazonia.DAL.Modelo.Livro");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("LivroPeriodico");
                });

            modelBuilder.Entity("Amazonia.DAL.Modelo.Cliente", b =>
                {
                    b.HasOne("Amazonia.DAL.Modelo.Morada", "Morada")
                        .WithMany()
                        .HasForeignKey("MoradaId");

                    b.Navigation("Morada");
                });
#pragma warning restore 612, 618
        }
    }
}
