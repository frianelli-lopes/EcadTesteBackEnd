using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Infra.Data.Context;
using EcadTeste.Infra.Data.Repositories;
using EcadTeste.Service;
using Microsoft.Extensions.DependencyInjection;

namespace EcadTeste.Infra.IoC
{
    public static class DIContainer
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<EcadTesteContext>();

            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IMusicaService, MusicaService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IAutorMusicaService, AutorMusicaService>();
                     
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IMusicaRepository, MusicaRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IAutorMusicaRepository, AutorMusicaRepository>();
        }
    }
}
