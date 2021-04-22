using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcadTeste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        // GET: api/Autor
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> GetAutor()
        {
            return _autorService.Listar();
        }

        // GET: api/Autor/5
        [HttpGet("{id}")]
        public ActionResult<Autor> GetAutor(Guid id)
        {
            var autor = _autorService.RecuperarPorId(id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // PUT: api/Autor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutAutor(Guid id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            try
            {
                _autorService.Alterar(autor);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Autor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Autor> PostAutor(Autor autor)
        {
            _autorService.Incluir(autor);

            return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);
        }

        // DELETE: api/Autor/5
        [HttpDelete("{id}")]
        public ActionResult DeleteAutor(Guid id)
        {
            var autor = _autorService.RecuperarPorId(id);
            if (autor == null)
            {
                return NotFound();
            }

            _autorService.Excluir(id);

            return NoContent();
        }
    }
}
