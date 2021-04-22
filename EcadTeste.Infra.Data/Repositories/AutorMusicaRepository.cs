using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;

namespace EcadTeste.Infra.Data.Repositories
{
    public class AutorMusicaRepository : BaseRepository<AutorMusica>, IAutorMusicaRepository
    {
        public AutorMusicaRepository(EcadTesteContext context) : base(context)
        {
        }
    }
}
