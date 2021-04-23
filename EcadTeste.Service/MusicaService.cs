using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;
using System;
using System.Collections.Generic;

namespace EcadTeste.Service
{
    public class MusicaService : BaseService<Musica>, IMusicaService
    {
        private readonly IMusicaRepository _musicaRepository;
        private readonly IAutorMusicaRepository _autorMusicaRepository;

        public MusicaService(IMusicaRepository repository, 
                             IAutorMusicaRepository autorMusicaRepository) : base(repository)
        {
            _musicaRepository = repository;
            _autorMusicaRepository = autorMusicaRepository;
        }

        public override void Alterar(Musica obj)
        {
            AutorMusica autorMusica = null;

            //Exclui os autores associados a música
            _autorMusicaRepository.ExcluirPorMusica(obj.Id);

            Musica musica = _musicaRepository.RecuperarMusicaGeneroAutores(obj.Id);
            musica.Codigo = obj.Codigo;
            musica.Nome = obj.Nome;

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

        public List<Musica> ListarMusicaGenero()
        {
            return _musicaRepository.ListarMusicaGenero();
        }

        public List<Musica> ListarMusicaGeneroAutores()
        {
            return _musicaRepository.ListarMusicaGeneroAutores();
        }

        public Musica RecuperarMusicaGenero(Guid id)
        {
            return _musicaRepository.RecuperarMusicaGenero(id);
        }

        public Musica RecuperarMusicaGeneroAutores(Guid id)
        {
            return _musicaRepository.RecuperarMusicaGeneroAutores(id);
        }
    }
}
