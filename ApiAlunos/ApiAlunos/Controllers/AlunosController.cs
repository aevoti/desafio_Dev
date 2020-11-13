using ApiAlunos.Context;
using ApiAlunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAlunos.DTOs;
using AutoMapper;

namespace ApiAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AlunosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Alunos
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAlunoDTO>>> GetAlunos()
        {
            var alunos = await _context.Alunos.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetAlunoDTO>>(alunos));
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<GetAlunoDTO>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetAlunoDTO>(aluno);
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Alunos
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<GetAlunoDTO>> PostAluno(InserirAlunoDTO aluno)
        {
            var novoAluno = _mapper.Map<Aluno>(aluno);
            _context.Alunos.Add(novoAluno);
            await _context.SaveChangesAsync();

            var alunoRetorno = _mapper.Map<GetAlunoDTO>(novoAluno);

            return CreatedAtAction("GetAluno", new { id = novoAluno.AlunoId }, alunoRetorno);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            var alunoRetorno = _mapper.Map<GetAlunoDTO>(aluno);

            return aluno;
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.AlunoId == id);
        }
    }
}
