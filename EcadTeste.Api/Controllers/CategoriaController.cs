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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService categoriaService,
                                   IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CategoriaDTO> Listar()
        {
            return _mapper.Map<IEnumerable<CategoriaDTO>>(_categoriaService.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoriaDTO> Recuperar(Guid id)
        {
            var categoria = _mapper.Map<CategoriaDTO>(_categoriaService.RecuperarPorId(id));

            if (categoria == null) return NotFound();

            return categoria;
        }

        [HttpPost]
        public ActionResult<CategoriaDTO> Incluir(CategoriaDTO categoria)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _categoriaService.Incluir(_mapper.Map<Categoria>(categoria));

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<CategoriaDTO> Alterar(Guid id, CategoriaDTO categoria)
        {
            if (id != categoria.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _categoriaService.Alterar(_mapper.Map<Categoria>(categoria));

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<CategoriaDTO> Excluir(Guid id)
        {
            //Verifica se o registro que será excluído existe
            var categoria = _mapper.Map<CategoriaDTO>(_categoriaService.RecuperarPorId(id));
            if (categoria == null) return NotFound();

            _categoriaService.Excluir(id);

            return Ok();
        }
    }
}
