using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;

namespace EcadTeste.Service
{
    public class AutorMusicaService : BaseService<AutorMusica>, IAutorMusicaService
    {
        public AutorMusicaService(IBaseRepository<AutorMusica> repository) : base(repository)
        {
        }
    }
}
