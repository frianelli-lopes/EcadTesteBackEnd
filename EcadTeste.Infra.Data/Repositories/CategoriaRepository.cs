using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;

namespace EcadTeste.Infra.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EcadTesteContext context) : base(context)
        {
        }
    }
}
