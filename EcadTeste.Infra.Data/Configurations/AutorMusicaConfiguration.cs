using EcadTeste.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcadTeste.Infra.Data.Configurations
{
    public class AutorMusicaConfiguration : IEntityTypeConfiguration<AutorMusica>
    {
        public void Configure(EntityTypeBuilder<AutorMusica> builder)
        {
            builder
                .HasKey(am => new { am.IdAutor, am.IdMusica })
                .HasName("PK_AutorMusica");

            builder
                .HasOne(am => am.Autor)
                .WithMany(a => a.Musicas)
                .HasForeignKey(a => a.IdAutor)
                .HasConstraintName("FK_AutorMusica_Autor");

            builder
                .HasOne(am => am.Musica)
                .WithMany(m => m.Autores)
                .HasForeignKey(a => a.IdMusica)
                .HasConstraintName("FK_AutorMusica_Musica");
        }
    }
}
