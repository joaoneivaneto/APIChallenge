using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIChallenge.Data;
using APIChallenge.DTO;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;

namespace APIChallenge.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ProjetosController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Projetoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }

        // GET: api/Projetoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);

            if (projeto == null)
            {
                return StatusCode(404, "Projeto Não Encontrado");
            }

            return projeto;
        }

        // PUT: api/Projetoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjeto(int id, CreateProjetoDTO request)
        {
            var empregado = await _context.Empregados.FindAsync(request.Gerente);
            var UpdateProjeto = new Projeto
            {
                id_projeto = id,
                nome = request.Nome,
                data_de_criação = request.Data_De_Criação,
                data_temino = request.Data_Termino,
                empregado = empregado,
            };
            if ( empregado == null)
            {
                return StatusCode(404, "O Gerente não foi encontrado");
            }
            if (request.Nome == "google")
            {
                return StatusCode(203,"esse nome não é permitido");
            }

            if(request.Data_De_Criação == request.Data_Termino)
            {
                return StatusCode(203, "as datas de criação e termino do projeto são iguais");
            }

            _context.Entry(UpdateProjeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(id))
                {
                    return StatusCode(404, "Projeto Não Encontrado");
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjeto", new { id = request.Id_Projeto }, request);
        }

        // POST: api/Projetoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Projeto>> PostProjeto(CreateProjetoDTO request)
        {
            var empregado = await _context.Empregados.FindAsync(request.Gerente);
            if(empregado == null)
            {
                return StatusCode(404, "O Gerente não foi encontrado");
            }
            var NewProjeto = new Projeto 
            {
                nome = request.Nome,
                data_de_criação = request.Data_De_Criação,
                data_temino = request.Data_Termino,
                empregado =  empregado,
            };
            _context.Projetos.Add(NewProjeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjeto", new { id = request.Id_Projeto }, request);
        }

        // DELETE: api/Projetoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return StatusCode(404, "O projeto não foi encontrado");
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projetos.Any(e => e.id_projeto == id);
        }
    }
}
