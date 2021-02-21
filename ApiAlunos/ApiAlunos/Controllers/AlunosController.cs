using DominioAlunos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositorioAlunos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IRepoAlunos _repo;

        public AlunosController(IRepoAlunos repo)
        {
            _repo = repo;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var results = await _repo.ObterTodos();

                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var results = await _repo.ObterPorId(id);

                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Aluno>> PutAluno(int id, Aluno aluno)
        {
            try
            {
                System.Console.WriteLine("Entrou no atualizar com valor de id = "+id);
                var localizarAluno = await _repo.ObterPorId(id);
                System.Console.WriteLine("Valor de localizarAluno.id = "+localizarAluno.Id);

                if(localizarAluno == null || aluno.Id != id)
                {
                    return NotFound();
                }

                _repo.Atualizar(localizarAluno);

                if(await _repo.SaveChanges())
                {
                    return Created($"/api/Alunos/{aluno.Id}", aluno);
                }
            }
            catch(System.Exception)
            {
                return this.StatusCode(500, "Alteraçao falhou!");
            }

            return BadRequest();
        }

        // POST: api/Alunos
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            try
            {
                _repo.Adicionar(aluno);

                if(await _repo.SaveChanges())
                {
                    return Created($"/api/Alunos/{aluno.Id}", aluno);
                }
            }
            catch(System.Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }

            return BadRequest();
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            try
            {
                var localizarAluno = await _repo.ObterPorId(id);

                if(localizarAluno == null)
                {
                    return NotFound();
                }

                _repo.Remover(localizarAluno);

                if(await _repo.SaveChanges())
                {
                    return Ok();
                }
            }
            catch(System.Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }

            return BadRequest();
        }
    }
}
