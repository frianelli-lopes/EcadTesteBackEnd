using System.Collections.Generic;

namespace EcadTeste.Domain.Models
{
    public class Genero : EntityBase
    {
        public string Nome { get; set; }

        public List<Musica> Musicas { get; set; }
    }
}
