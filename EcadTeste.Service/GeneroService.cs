using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;

namespace EcadTeste.Service
{
    public class GeneroService : BaseService<Genero>, IGeneroService
    {
        public GeneroService(IGeneroRepository repository) : base(repository)
        {
        }
    }
}
