using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIChallenge.Data;
using APIChallenge.DTO;

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
        public async Task<ActionResult<IEnumerable<Membro>>> Getmembros()
        {
            return await _context.membros.ToListAsync();
        }

        // GET: api/Membros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Membro>> GetMembro(int id)
        {
            var membro = await _context.membros.FindAsync(id);

            if (membro == null)
            {
                return NotFound();
            }

            return membro;
        }

        // PUT: api/Membros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembro(int id, Membro membro)
        {
            if (id != membro.id_projeto)
            {
                return BadRequest();
            }

            _context.Entry(membro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembroExists(id))
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
        public async Task<ActionResult<Membro>> PostMembro(MembrosDTO request)
        {
            var empregado = await _context.Empregados.FindAsync(request.Id_Empregado);
            var projeto = await _context.Projetos.FindAsync(request.Id_Projeto);
            var newMembro = new Membro
            {
                empregado = empregado,
                projeto = projeto,
            };
            _context.membros.Add(newMembro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MembroExists(request.Id_Projeto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMembro", new { id = request.Id_Projeto }, request);
        }

        // DELETE: api/Membros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembro(int id)
        {
            var membro = await _context.membros.FindAsync(id);
            if (membro == null)
            {
                return NotFound();
            }

            _context.membros.Remove(membro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembroExists(int id)
        {
            return _context.membros.Any(e => e.id_projeto == id);
        }
    }
}
