using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcadTeste.Api.DTOs
{
    public class MusicaResponseDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public Guid IdGenero { get; set; }

        public string NomeGenero { get; set; }

        public List<AutorMusicaResponseDTO> AutoresMusicas { get; set; }

    }
}
