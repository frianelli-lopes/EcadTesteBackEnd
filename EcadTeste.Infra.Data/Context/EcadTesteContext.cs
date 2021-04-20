using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EcadTeste.Infra.Data.Context
{
    public class EcadTesteContext : DbContext
    {
        public EcadTesteContext(DbContextOptions<EcadTesteContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Musica> Musica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicaConfiguration());
            modelBuilder.ApplyConfiguration(new AutorConfiguration());
            modelBuilder.ApplyConfiguration(new AutorMusicaConfiguration());
            modelBuilder.ApplyConfiguration(new GeneroConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
