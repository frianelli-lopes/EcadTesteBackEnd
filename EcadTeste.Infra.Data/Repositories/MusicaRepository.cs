using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcadTeste.Infra.Data.Repositories
{
    public class MusicaRepository : BaseRepository<Musica>, IMusicaRepository
    {
        public MusicaRepository(EcadTesteContext context) : base(context)
        {
        }

        public List<Musica> ListarMusicaGenero()
        {
            return Db.Musica.AsNoTracking()
                .Include(m => m.Genero)
                .ToList();
        }

        public List<Musica> ListarMusicaGeneroAutores()
        {
            return Db.Musica.AsNoTracking()
                .Include(m => m.Genero)
                .Include(m => m.AutoresMusicas)
                .ToList();
        }

        public Musica RecuperarMusicaGenero(Guid id)
        {
            return Db.Musica.AsNoTracking()
                .Include(m => m.Genero)
                .FirstOrDefault(m => m.Id == id);
        }

        public Musica RecuperarMusicaGeneroAutores(Guid id)
        {
            return Db.Musica.AsNoTracking()
                .Include(m => m.Genero)
                .Include(m => m.AutoresMusicas)
                .FirstOrDefault(m => m.Id == id);
        }
    }
}
