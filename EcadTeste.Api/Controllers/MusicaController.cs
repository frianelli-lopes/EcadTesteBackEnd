using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;

namespace EcadTeste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly EcadTesteContext _context;

        public MusicaController(EcadTesteContext context)
        {
            _context = context;
        }

        // GET: api/Musica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musica>>> GetMusica()
        {
            return await _context.Musica.ToListAsync();
        }

        // GET: api/Musica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musica>> GetMusica(Guid id)
        {
            var musica = await _context.Musica.FindAsync(id);

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
        public async Task<IActionResult> PutMusica(Guid id, Musica musica)
        {
            if (id != musica.Id)
            {
                return BadRequest();
            }

            _context.Entry(musica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Musica
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Musica>> PostMusica(Musica musica)
        {
            _context.Musica.Add(musica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusica", new { id = musica.Id }, musica);
        }

        // DELETE: api/Musica/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Musica>> DeleteMusica(Guid id)
        {
            var musica = await _context.Musica.FindAsync(id);
            if (musica == null)
            {
                return NotFound();
            }

            _context.Musica.Remove(musica);
            await _context.SaveChangesAsync();

            return musica;
        }

        private bool MusicaExists(Guid id)
        {
            return _context.Musica.Any(e => e.Id == id);
        }
    }
}
