using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcadTeste.Infra.Data.Seeds
{
    public class SeedCategoria
    {
        public static void Carregar(EcadTesteContext context)
        {
            if (!context.Categoria.Any())
            {
                IList<Categoria> listaCategorias = new List<Categoria>() {
                    new Categoria() {Id = Guid.NewGuid(), Nome="Autor"},
                    new Categoria() {Id = Guid.NewGuid(), Nome="Compositor"},
                    new Categoria() {Id = Guid.NewGuid(), Nome="Intérprete"},
                    new Categoria() {Id = Guid.NewGuid(), Nome="Músico"},
                };

                context.Categoria.AddRange(listaCategorias);
                context.SaveChanges();
            }
        }
    }
}
