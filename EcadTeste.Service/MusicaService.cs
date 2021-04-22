using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;

namespace EcadTeste.Service
{
    public class MusicaService : BaseService<Musica>, IMusicaService
    {
        public MusicaService(IMusicaRepository repository) : base(repository)
        {
        }
    }
}
