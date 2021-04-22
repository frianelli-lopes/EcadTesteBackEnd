using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcadTeste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        // GET: api/Genero
        [HttpGet]
        public ActionResult<IEnumerable<Genero>> GetGenero()
        {
            return _generoService.Listar();
        }

        // GET: api/Genero/5
        [HttpGet("{id}")]
        public ActionResult<Genero> GetGenero(Guid id)
        {
            var genero = _generoService.RecuperarPorId(id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        // PUT: api/Genero/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutGenero(Guid id, Genero genero)
        {
            if (id != genero.Id)
            {
                return BadRequest();
            }

            try
            {
                _generoService.Alterar(genero);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Genero
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Genero> PostGenero(Genero genero)
        {
            _generoService.Incluir(genero);

            return CreatedAtAction("GetGenero", new { id = genero.Id }, genero);
        }

        // DELETE: api/Genero/5
        [HttpDelete("{id}")]
        public ActionResult DeleteGenero(Guid id)
        {
            var genero = _generoService.RecuperarPorId(id);
            if (genero == null)
            {
                return NotFound();
            }

            _generoService.Excluir(id);

            return NoContent();
        }
    }
}
