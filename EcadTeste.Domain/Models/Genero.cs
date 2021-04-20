﻿using System;
using System.Collections.Generic;

namespace EcadTeste.Domain.Models
{
    public class Genero
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public List<Musica> Musicas { get; set; }
    }
}
