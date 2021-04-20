using EcadTeste.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcadTeste.Infra.Data.Configurations
{
    public class MusicaConfiguration : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            //Propriedades
            builder.Property(p => p.Codigo).HasColumnType("varchar(20)").HasMaxLength(20).IsRequired();

            builder.Property(p => p.Nome).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();


            //Chaves
            builder.HasKey(p => p.Id).HasName("PK_Musica");

            //Chaves estrangeiras
            builder.HasOne(m => m.Genero)
                .WithMany(g => g.Musicas)
                .HasConstraintName("FK_Musica_Genero")
                .HasForeignKey(p => p.IdGenero)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
