﻿// <auto-generated />
using System;
using CONECTA_BRASIL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CONECTA_BRASIL.Migrations
{
    [DbContext(typeof(CONECTA_BRASILContext))]
    partial class CONECTA_BRASILContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CONECTA_BRASIL.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.PagInicial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("PagInicial");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.Publicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CriadorId")
                        .HasColumnType("int");

                    b.Property<int?>("PagInicialId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CriadorId");

                    b.HasIndex("PagInicialId");

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.PublicacaoCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("PublicacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("PublicacaoId");

                    b.ToTable("PublicacaoCategorias");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasDiscriminator().HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.Instituicao", b =>
                {
                    b.HasBaseType("CONECTA_BRASIL.Models.Usuario");

                    b.Property<string>("Atuacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Instituicao");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.Pessoa", b =>
                {
                    b.HasBaseType("CONECTA_BRASIL.Models.Usuario");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Pessoa");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.Categoria", b =>
                {
                    b.HasOne("CONECTA_BRASIL.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.Publicacao", b =>
                {
                    b.HasOne("CONECTA_BRASIL.Models.Usuario", "Criador")
                        .WithMany()
                        .HasForeignKey("CriadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CONECTA_BRASIL.Models.PagInicial", null)
                        .WithMany("Publicacoes")
                        .HasForeignKey("PagInicialId");

                    b.Navigation("Criador");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.PublicacaoCategoria", b =>
                {
                    b.HasOne("CONECTA_BRASIL.Models.Categoria", "Categoria")
                        .WithMany("PublicacaoCategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CONECTA_BRASIL.Models.Publicacao", "Publicacao")
                        .WithMany("PublicacaoCategorias")
                        .HasForeignKey("PublicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Publicacao");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.Categoria", b =>
                {
                    b.Navigation("PublicacaoCategorias");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.PagInicial", b =>
                {
                    b.Navigation("Publicacoes");
                });

            modelBuilder.Entity("CONECTA_BRASIL.Models.Publicacao", b =>
                {
                    b.Navigation("PublicacaoCategorias");
                });
#pragma warning restore 612, 618
        }
    }
}
