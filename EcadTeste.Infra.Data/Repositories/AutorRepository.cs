using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;

namespace EcadTeste.Infra.Data.Repositories
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(EcadTesteContext context) : base(context)
        {
        }
    }
}
