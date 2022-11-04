using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIChallenge.Data;
using APIChallenge.DTO;
using Microsoft.AspNetCore.Authorization;

namespace APIChallenge.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpregadosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public EmpregadosController(AppDBContext context)
        {
            _context = context;
        }
        
        // GET: api/Empregados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empregado>>> GetEmpregados()
        {
            return await _context.Empregados.ToListAsync();
        }

        // GET: api/Empregados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empregado>> GetEmpregado(int id)
        {
            var empregado = await _context.Empregados.FindAsync(id);

            if (empregado == null)
            {
                return StatusCode(404, "O Empregado não foi encontrado");
            }

            return empregado;
        }

        [ClaimsAuthorize("Empregado","Editar")]
        // PUT: api/Empregados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpregado(int id, CreateEmpregadoDTO request)
        {
           

            var UpdateEmpregado = new Empregado
            {
                id_empregado = id,
                primeiro_nome = request.Primeiro_Nome,
                ultimo_nome = request.Ultimo_Nome,
                telefone = request.Telefone,
                endereco = request.Endereco,
            };

            



            _context.Entry(UpdateEmpregado).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpregadoExists(id))
                {
                    return StatusCode(404, "O Empregado não foi encontrado");
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpregado", new { id = request.Id_Empregado }, request);

        }

        [ClaimsAuthorize("Empregado", "Incluir")]
        // POST: api/Empregados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empregado>> PostEmpregado(CreateEmpregadoDTO request)
        {
            
            var newEmpregado = new Empregado
            {
                primeiro_nome = request.Primeiro_Nome,
                ultimo_nome = request.Ultimo_Nome,
                telefone = request.Telefone,
                endereco = request.Endereco,
            };
            _context.Empregados.Add(newEmpregado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpregado", new { id = request.Id_Empregado   }, request);
        }
        [ClaimsAuthorize("Empregado", "Excluir")]
        // DELETE: api/Empregados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpregado(int id)
        {
            var empregado = await _context.Empregados.FindAsync(id);
            if (empregado == null)
            {
                return StatusCode(404, "O Empregado não foi encontrado");
            }

            _context.Empregados.Remove(empregado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpregadoExists(int id)
        {
            return _context.Empregados.Any(e => e.id_empregado == id);
        }
    }
}
