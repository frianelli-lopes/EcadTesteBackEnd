using System;

namespace EcadTeste.Api.DTOs
{
    public class AutorMusicaResponseDTO
    {
        public Guid IdAutor { get; set; }
        
        public string NomeAutor { get; set; }

        public Guid IdCategoria { get; set; }

        public string NomeCategoria { get; set; }
    }
}
