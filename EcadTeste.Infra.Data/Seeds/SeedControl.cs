using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcadTeste.Infra.Data.Seeds
{
    public static class SeedControl
    {
        public static void Seed(this EcadTesteContext context)
        {
            if (!context.Genero.Any())
            {
                IList<Genero> listaGeneros = new List<Genero>() {
                    new Genero() {Id = Guid.NewGuid(), Nome="Gospel"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Rock"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Metal"},
                    new Genero() {Id = Guid.NewGuid(), Nome="MPB"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Sertanejo"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Pagode"}
                };

                context.Genero.AddRange(listaGeneros);
                context.SaveChanges();
            }

            if (!context.Categoria.Any())
            {
                IList<Categoria> listaCategorias = new List<Categoria>() {
                    new Categoria() {Id = Guid.NewGuid(), Nome="Autor"},
                    new Categoria() {Id = Guid.NewGuid(), Nome="Compositor"},
                    new Categoria() {Id = Guid.NewGuid(), Nome="Intérprete"},
                    new Categoria() {Id = Guid.NewGuid(), Nome="Músico"}
                };

                context.Categoria.AddRange(listaCategorias);
                context.SaveChanges();
            }

            if (!context.Autor.Any())
            {
                IList<Autor> listaAutores = new List<Autor>()
                {
                    new Autor() {Id = Guid.NewGuid(), Codigo="RC01", Nome="Roberto Carlos"},
                    new Autor() {Id = Guid.NewGuid(), Codigo="EC01", Nome="Erasmo Carlos"},
                    new Autor() {Id=Guid.NewGuid(), Codigo="FV01", Nome="Flavio Venturini"}
                };

                context.Autor.AddRange(listaAutores);
                context.SaveChanges();
            }

            if (!context.Musica.Any())
            {
                IList<Musica> listaMusicas = new List<Musica>()
                {
                    new Musica() {
                        Id=Guid.NewGuid(),
                        Codigo="01",
                        Nome="Detalhes",
                        Genero=context.Genero.Where(g => g.Nome == "MPB").FirstOrDefault(),
                        AutoresMusicas = new List<AutorMusica>()
                        {
                            new AutorMusica()
                            {
                                Autor = context.Autor.Where(a => a.Nome == "Roberto Carlos").FirstOrDefault(),
                                Categoria = context.Categoria.Where(c => c.Nome == "Compositor").FirstOrDefault()
                            },
                            new AutorMusica()
                            {
                                Autor = context.Autor.Where(a => a.Nome == "Erasmo Carlos").FirstOrDefault(),
                                Categoria = context.Categoria.Where(c => c.Nome == "Compositor").FirstOrDefault()
                            },
                            new AutorMusica()
                            {
                                Autor = context.Autor.Where(a => a.Nome == "Roberto Carlos").FirstOrDefault(),
                                Categoria = context.Categoria.Where(c => c.Nome == "Intérprete").FirstOrDefault()
                            }
                        }
                    }
                };

                context.Musica.AddRange(listaMusicas);
                context.SaveChanges();
            }
        }
    }
}
