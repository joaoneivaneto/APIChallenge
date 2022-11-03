using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIChallenge.Data;
using Microsoft.AspNetCore.Authorization;

namespace APIChallenge.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<List<Membro>>> GetProjeto(int id)
        {
          
            var membro = await _context.membros
                 .Where(x => x.id_projeto == id)
                 .ToListAsync();

            if (ProjetoExists(id))
            {
                return membro;
            }

            return StatusCode(204, "ERRO!Relação Não encontrada");
           
        }

        

   

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
                if (EmpregadoExists(membro.id_empregado) || ProjetoExists(membro.id_projeto))
                {
                    return StatusCode(409, "ERRO! Essa relação Ja existe");
                }
                else
                {
                    return StatusCode(404, "ERRO!Dados Não Encontrados");
                }
            }

            return CreatedAtAction("GetProjeto", new { id = membro.id_empregado }, membro);
        }

        

        private bool EmpregadoExists(int id)
        {
            return _context.membros.Any(e => e.id_empregado == id);
        }
        private bool ProjetoExists(int id)
        {
            return _context.membros.Any(e => e.id_projeto == id);
        }

    }
}
