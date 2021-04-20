using EcadTeste.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcadTeste.Infra.Data.Configurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            //Propriedades
            builder.Property(p => p.Codigo).HasColumnType("varchar(20)").HasMaxLength(20).IsRequired();

            builder.Property(p => p.Nome).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();


            //Chaves
            builder.HasKey(p => p.Id).HasName("PK_Autor");

            //Chaves estrangeiras
            builder.HasOne(a => a.Categoria)
                .WithMany(c => c.Autores)
                .HasConstraintName("FK_Autor_Categoria")
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
