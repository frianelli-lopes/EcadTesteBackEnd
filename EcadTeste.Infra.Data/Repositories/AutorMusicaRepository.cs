using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcadTeste.Infra.Data.Repositories
{
    public class AutorMusicaRepository : BaseRepository<AutorMusica>, IAutorMusicaRepository
    {
        public AutorMusicaRepository(EcadTesteContext context) : base(context)
        {
        }

        public void ExcluirPorMusica(Guid idMusica)
        {
            List<AutorMusica> autores = Db.Set<AutorMusica>().Where(am => am.IdMusica == idMusica).ToList();
            Db.RemoveRange(autores);
            SaveChanges();
        }
    }
}
