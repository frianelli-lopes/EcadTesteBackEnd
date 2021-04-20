using System;
using System.Collections.Generic;

namespace EcadTeste.Domain.Models
{
    public class Autor
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public Guid IdCategoria { get; set; }

        public Categoria Categoria { get; set; }
        public virtual List<AutorMusica> Musicas { get; set; }
    }
}
