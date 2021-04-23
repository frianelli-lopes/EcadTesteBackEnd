using System.Collections.Generic;

namespace EcadTeste.Domain.Models
{
    public class Autor : EntityBase
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public virtual List<AutorMusica> AutoresMusicas { get; set; }
    }
}
