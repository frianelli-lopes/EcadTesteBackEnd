using EcadTeste.Domain.Models;
using System;
using System.Collections.Generic;

namespace EcadTeste.Domain.Interfaces.Services
{
    public interface IMusicaService : IBaseService<Musica>
    {
        List<Musica> ListarMusicaGenero();
        List<Musica> ListarMusicaGeneroAutores();
        Musica RecuperarMusicaGenero(Guid id);
        Musica RecuperarMusicaGeneroAutores(Guid id);
    }
}
