using EcadTeste.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcadTeste.Infra.Data.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //Propriedades
            builder.Property(p => p.Nome).HasColumnType("varchar(30)").HasMaxLength(30).IsRequired();

            //Chaves
            builder.HasKey(p => p.Id).HasName("PK_Catagoria");
        }
    }
}
