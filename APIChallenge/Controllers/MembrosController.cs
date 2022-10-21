using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIChallenge.Data;

namespace APIChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembrosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MembrosController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Membros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Membros>>> GetMembros()
        {
            return await _context.Membros.ToListAsync();
        }

        // GET: api/Membros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Membros>> GetMembros(int id)
        {
            var membros = await _context.Membros.FindAsync(id);

            if (membros == null)
            {
                return NotFound();
            }

            return membros;
        }

        // PUT: api/Membros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembros(int id, Membros membros)
        {
            if (id != membros.id_empregado)
            {
                return BadRequest();
            }

            _context.Entry(membros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembrosExists(id))
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

        // POST: api/Membros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Membros>> PostMembros(Membros membros)
        {
            _context.Membros.Add(membros);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MembrosExists(membros.id_empregado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMembros", new { id = membros.id_empregado }, membros);
        }

        // DELETE: api/Membros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembros(int id)
        {
            var membros = await _context.Membros.FindAsync(id);
            if (membros == null)
            {
                return NotFound();
            }

            _context.Membros.Remove(membros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembrosExists(int id)
        {
            return _context.Membros.Any(e => e.id_empregado == id);
        }
    }
}
