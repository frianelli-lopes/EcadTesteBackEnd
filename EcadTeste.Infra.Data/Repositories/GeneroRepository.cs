using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;

namespace EcadTeste.Infra.Data.Repositories
{
    public class GeneroRepository : BaseRepository<Genero>, IGeneroRepository
    {
        public GeneroRepository(EcadTesteContext context) : base(context)
        {
        }
    }
}
