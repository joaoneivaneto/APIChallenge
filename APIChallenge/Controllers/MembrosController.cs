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
        public async Task<ActionResult<IEnumerable<Membro>>> Getmembros()
        {
            return await _context.membros.ToListAsync();
        }

        // GET: api/Membros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Membro>>> GetMembro(int id)
        {
          
            var membro = await _context.membros
                 .Where(x => x.id_projeto == id)
                 .ToListAsync();
           
            if (!MembroExists(id))
            {
                return NotFound();
            }

            return membro;
        }

        // PUT: api/Membros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        // POST: api/Membros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Membro>> PostMembro(Membro membro)
        {
            _context.membros.Add(membro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MembroExists(membro.id_empregado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMembro", new { id = membro.id_empregado }, membro);
        }

        

        private bool MembroExists(int id)
        {
            return _context.membros.Any(e => e.id_empregado == id);
        }
    }
}
