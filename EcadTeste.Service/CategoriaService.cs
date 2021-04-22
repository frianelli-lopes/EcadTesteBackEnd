using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;

namespace EcadTeste.Service
{
    public class CategoriaService : BaseService<Categoria>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
        }
    }
}
