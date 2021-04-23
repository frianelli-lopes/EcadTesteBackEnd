using AutoMapper;
using EcadTeste.Api.DTOs;
using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EcadTeste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly IMusicaService _musicaService;
        private readonly IMapper _mapper;

        public MusicaController(IMusicaService musicaService,
                               IMapper mapper)
        {
            _musicaService = musicaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<MusicaResponseDTO> Listar()
        {
            return _mapper.Map<IEnumerable<MusicaResponseDTO>>(_musicaService.ListarMusicaGenero());
        }

        [HttpGet("{id}")]
        public ActionResult<MusicaResponseDTO> Recuperar(Guid id)
        {
            var autor = _mapper.Map<MusicaResponseDTO>(_musicaService.RecuperarMusicaGenero(id));

            if (autor == null) return NotFound();

            return autor;
        }

        [HttpPost]
        public ActionResult<MusicaRequestDTO> Incluir(MusicaRequestDTO musica)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _musicaService.Incluir(_mapper.Map<Musica>(musica));

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<MusicaRequestDTO> Alterar(Guid id, MusicaRequestDTO musica)
        {
            if (id != musica.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _musicaService.Alterar(_mapper.Map<Musica>(musica));

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Excluir(Guid id)
        {
            //Verifica se o registro que será excluído existe
            var autor = _mapper.Map<MusicaResponseDTO>(_musicaService.RecuperarPorId(id));
            if (autor == null) return NotFound();

            _musicaService.Excluir(id);

            return Ok();
        }
    }
}
