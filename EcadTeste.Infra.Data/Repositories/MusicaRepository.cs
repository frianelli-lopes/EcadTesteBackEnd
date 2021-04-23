using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;
using System;

namespace EcadTeste.Infra.Data.Repositories
{
    public class MusicaRepository : BaseRepository<Musica>, IMusicaRepository
    {
        public MusicaRepository(EcadTesteContext context) : base(context)
        {
        }

        public override Musica RecuperarPorId(Guid id)
        {
            Musica musica = base.RecuperarPorId(id);

            db.Entry<Musica>(musica).Collection("AutoresMusicas").Load();

            return musica;
        }
    }
}
