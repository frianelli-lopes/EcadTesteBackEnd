using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;
using System;

namespace EcadTeste.Service
{
    public class AutorMusicaService : BaseService<AutorMusica>, IAutorMusicaService
    {
        public AutorMusicaService(IAutorMusicaRepository repository) : base(repository)
        {
        }
    }
}
