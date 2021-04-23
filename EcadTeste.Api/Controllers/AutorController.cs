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
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        private readonly IMapper _mapper;

        public AutorController(IAutorService autorService,
                               IMapper mapper)
        {
            _autorService = autorService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AutorDTO> Listar()
        {
            return _mapper.Map<IEnumerable<AutorDTO>>(_autorService.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<AutorDTO> Recuperar(Guid id)
        {
            var autor = _mapper.Map<AutorDTO>(_autorService.RecuperarPorId(id));

            if (autor == null) return NotFound();

            return autor;
        }

        [HttpPost]
        public ActionResult<AutorDTO> Incluir(AutorDTO autor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _autorService.Incluir(_mapper.Map<Autor>(autor));

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<AutorDTO> Alterar(Guid id, AutorDTO autor)
        {
            if (id != autor.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _autorService.Alterar(_mapper.Map<Autor>(autor));

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<AutorDTO> Excluir(Guid id)
        {
            //Verifica se o registro que será excluído existe
            var autor = _mapper.Map<AutorDTO>(_autorService.RecuperarPorId(id));
            if (autor == null) return NotFound();

            _autorService.Excluir(id);

            return Ok();
        }
    }
}
