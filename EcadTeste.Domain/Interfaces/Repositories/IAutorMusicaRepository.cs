using EcadTeste.Domain.Models;
using System;

namespace EcadTeste.Domain.Interfaces.Repositories
{
    public interface IAutorMusicaRepository : IBaseRepository<AutorMusica>
    {
        void ExcluirPorMusica(Guid idMusica);
    }
}
