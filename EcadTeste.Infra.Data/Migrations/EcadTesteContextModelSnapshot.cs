﻿// <auto-generated />
using System;
using EcadTeste.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcadTeste.Infra.Data.Migrations
{
    [DbContext(typeof(EcadTesteContext))]
    partial class EcadTesteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcadTeste.Domain.Models.Autor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("PK_Autor");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("EcadTeste.Domain.Models.AutorMusica", b =>
                {
                    b.Property<Guid>("IdAutor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMusica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdCategoria")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdAutor", "IdMusica", "IdCategoria")
                        .HasName("PK_AutorMusica");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdMusica");

                    b.ToTable("AutorMusica");
                });

            modelBuilder.Entity("EcadTeste.Domain.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id")
                        .HasName("PK_Catagoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("EcadTeste.Domain.Models.Genero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id")
                        .HasName("PK_Genero");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("EcadTeste.Domain.Models.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<Guid>("IdGenero")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("PK_Musica");

                    b.HasIndex("IdGenero");

                    b.ToTable("Musica");
                });

            modelBuilder.Entity("EcadTeste.Domain.Models.AutorMusica", b =>
                {
                    b.HasOne("EcadTeste.Domain.Models.Autor", "Autor")
                        .WithMany("AutoresMusicas")
                        .HasForeignKey("IdAutor")
                        .HasConstraintName("FK_AutorMusica_Autor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcadTeste.Domain.Models.Categoria", "Categoria")
                        .WithMany("AutoresMusicas")
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("FK_AutorMusica_Categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcadTeste.Domain.Models.Musica", "Musica")
                        .WithMany("AutoresMusicas")
                        .HasForeignKey("IdMusica")
                        .HasConstraintName("FK_AutorMusica_Musica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcadTeste.Domain.Models.Musica", b =>
                {
                    b.HasOne("EcadTeste.Domain.Models.Genero", "Genero")
                        .WithMany("Musicas")
                        .HasForeignKey("IdGenero")
                        .HasConstraintName("FK_Musica_Genero")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
