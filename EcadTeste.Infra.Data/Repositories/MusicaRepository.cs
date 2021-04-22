using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;

namespace EcadTeste.Infra.Data.Repositories
{
    public class MusicaRepository : BaseRepository<Musica>, IMusicaRepository
    {
        public MusicaRepository(EcadTesteContext context) : base(context)
        {
        }
    }
}
