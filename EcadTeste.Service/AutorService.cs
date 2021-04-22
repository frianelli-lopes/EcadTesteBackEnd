using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;

namespace EcadTeste.Service
{
    public class AutorService : BaseService<Autor>, IAutorService
    {
        public AutorService(IAutorRepository repository) : base(repository)
        {
        }
    }
}
