using AutoMapper;
using EcadTeste.Api.DTOs;
using EcadTeste.Domain.Models;

namespace EcadTeste.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Autor, AutorDTO>().ReverseMap();
            
            CreateMap<MusicaRequestDTO, Musica>();
            CreateMap<AutorMusicaRequestDTO, AutorMusica>();

            CreateMap<Musica, MusicaResponseDTO>()
                .AfterMap((src, dest) =>
                {
                    dest.NomeGenero = src.Genero != null ? src.Genero.Nome : null;
                }
                );

            CreateMap<AutorMusica, AutorMusicaResponseDTO>()
                .AfterMap((src, dest) =>
                {
                    dest.NomeAutor = src.Autor != null ? src.Autor.Nome : null;
                    dest.NomeCategoria = src.Categoria != null ? src.Categoria.Nome : null;
                }
                );
        }
    }
}
