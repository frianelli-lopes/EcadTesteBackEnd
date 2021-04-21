using System;

namespace EcadTeste.Domain.Models
{
    public class AutorMusica
    {
        public Guid IdAutor { get; set; }
        public Guid IdMusica { get; set; }
        public Guid IdCategoria { get; set; }


        public Autor Autor { get; set; }
        public Musica Musica { get; set; }
        public Categoria Categoria { get; set; }
    }
}
