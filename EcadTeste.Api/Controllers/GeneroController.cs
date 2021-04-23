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
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;
        private readonly IMapper _mapper;

        public GeneroController(IGeneroService generoService,
                                IMapper mapper)
        {
            _generoService = generoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<GeneroDTO> Listar()
        {
            return _mapper.Map<IEnumerable<GeneroDTO>>(_generoService.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<GeneroDTO> Recuperar(Guid id)
        {
            var genero = _mapper.Map<GeneroDTO>(_generoService.RecuperarPorId(id));

            if (genero == null) return NotFound();
            
            return genero;
        }

        [HttpPost]
        public ActionResult<GeneroDTO> Incluir(GeneroDTO genero)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _generoService.Incluir(_mapper.Map<Genero>(genero));

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<GeneroDTO> Alterar(Guid id, GeneroDTO genero)
        {
            if (id != genero.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _generoService.Alterar(_mapper.Map<Genero>(genero));

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<GeneroDTO> Excluir(Guid id)
        {
            //Verifica se o registro que será excluído existe
            var genero = _mapper.Map<GeneroDTO>(_generoService.RecuperarPorId(id));
            if (genero == null) return NotFound();

            _generoService.Excluir(id);

            return Ok();
        }
    }
}
