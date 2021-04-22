using EcadTeste.Domain.Interfaces.Services;
using EcadTeste.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EcadTeste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly IMusicaService _musicaService;

        public MusicaController(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        // GET: api/Musica
        [HttpGet]
        public ActionResult<IEnumerable<Musica>> GetMusica()
        {
            return _musicaService.Listar();
        }

        // GET: api/Musica/5
        [HttpGet("{id}")]
        public ActionResult<Musica> GetMusica(Guid id)
        {
            var musica = _musicaService.RecuperarPorId(id);

            if (musica == null)
            {
                return NotFound();
            }

            return musica;
        }

        // PUT: api/Musica/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutMusica(Guid id, Musica musica)
        {
            if (id != musica.Id)
            {
                return BadRequest();
            }

            try
            {
                _musicaService.Alterar(musica);
            }
            catch (DbUpdateConcurrencyException)
            {                
                throw;
            }

            return NoContent();
        }

        // POST: api/Musica
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Musica> PostMusica(Musica musica)
        {
            _musicaService.Incluir(musica);

            return CreatedAtAction("GetMusica", new { id = musica.Id }, musica);
        }

        // DELETE: api/Musica/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMusica(Guid id)
        {
            var musica = _musicaService.RecuperarPorId(id);
            if (musica == null)
            {
                return NotFound();
            }

            _musicaService.Excluir(id);

            return NoContent();
        }
    }
}
