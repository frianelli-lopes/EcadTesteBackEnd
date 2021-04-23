﻿using System;
using System.Collections.Generic;

namespace EcadTeste.Domain.Models
{
    public class Musica : EntityBase
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public Guid IdGenero { get; set; }

        public Genero Genero { get; set; }
        public virtual List<AutorMusica> AutoresMusicas { get; set; }
    }
}
