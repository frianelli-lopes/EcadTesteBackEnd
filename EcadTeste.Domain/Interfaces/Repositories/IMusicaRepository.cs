using EcadTeste.Domain.Models;
using System;
using System.Collections.Generic;

namespace EcadTeste.Domain.Interfaces.Repositories
{
    public interface IMusicaRepository : IBaseRepository<Musica>
    {
        List<Musica> ListarMusicaGenero();
        List<Musica> ListarMusicaGeneroAutores();
        Musica RecuperarMusicaGenero(Guid id);
        Musica RecuperarMusicaGeneroAutores(Guid id);
    }
}
