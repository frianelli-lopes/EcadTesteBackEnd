using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcadTeste.Infra.Data.Seeds
{
    public class SeedGenero
    {
        public static void Carregar(EcadTesteContext context)
        {
            if (!context.Genero.Any())
            {
                IList<Genero> listaGeneros = new List<Genero>() {
                    new Genero() {Id = Guid.NewGuid(), Nome="Axé"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Blues"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Gospel"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Rock"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Metal"},
                    new Genero() {Id = Guid.NewGuid(), Nome="MPB"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Sertanejo"},
                    new Genero() {Id = Guid.NewGuid(), Nome="Pagode"},
                };

                context.Genero.AddRange(listaGeneros);
                context.SaveChanges();
            }
        }
    }
}
