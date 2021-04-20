using System;

namespace EcadTeste.Domain.Models
{
    public class AutorMusica
    {
        public Guid IdAutor { get; set; }
        public Guid IdMusica { get; set; }


        public Autor Autor { get; set; }
        public Musica Musica { get; set; }
    }
}
