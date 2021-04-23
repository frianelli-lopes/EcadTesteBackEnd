using System.Collections.Generic;

namespace EcadTeste.Domain.Models
{
    public class Categoria : EntityBase
    {
        public string Nome { get; set; }

        public virtual List<AutorMusica> AutoresMusicas { get; set; }
    }
}
