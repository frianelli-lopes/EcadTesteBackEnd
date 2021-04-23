using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;
using System;

namespace EcadTeste.Service
{
    public class MusicaService : BaseService<Musica>, IMusicaService
    {
        private readonly IAutorService _autorService;
        private readonly ICategoriaService _categoriaService;

        public MusicaService(
            IMusicaRepository repository, 
            IAutorService autorService,
            ICategoriaService categoriaService
            ) : base(repository)
        {
            _autorService = autorService;
            _categoriaService = categoriaService;
        }

        public override void Alterar(Musica obj)
        {
            AutorMusica autorMusica = null;

            Musica musica = _repository.RecuperarPorId(obj.Id);
            musica.Codigo = obj.Codigo;
            musica.Nome = obj.Nome;
            musica.AutoresMusicas.Clear();

            if (obj.AutoresMusicas != null)
            {
                foreach (var am in obj.AutoresMusicas)
                {
                    autorMusica = new AutorMusica();
                    autorMusica.IdAutor = am.IdAutor;
                    autorMusica.IdCategoria = am.IdCategoria;

                    musica.AutoresMusicas.Add(autorMusica);
                }
            }

            base.Alterar(musica);
        }
    }
}
