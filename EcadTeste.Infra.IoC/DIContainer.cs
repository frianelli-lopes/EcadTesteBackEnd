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

            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<IMusicaService, MusicaService>();
            services.AddTransient<IGeneroService, GeneroService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IAutorMusicaService, AutorMusicaService>();

            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IMusicaRepository, MusicaRepository>();
            services.AddTransient<IGeneroRepository, GeneroRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IAutorMusicaRepository, AutorMusicaRepository>();
        }
    }
}
