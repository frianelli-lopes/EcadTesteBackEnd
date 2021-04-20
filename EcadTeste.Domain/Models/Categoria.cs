using System;
using System.Collections.Generic;

namespace EcadTeste.Domain.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public List<Autor> Autores { get; set; }
    }
}
