using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public AlunosController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/Alunos
        [HttpGet]
        public IActionResult GetAlunos([FromQuery] AlunoParameters parameters)
        {
            var alunos = _repo.Aluno.GetAlunos(parameters);

            var metadata = new
            {
                alunos.TotalCount,
                alunos.PageSize,
                alunos.CurrentPage,
                alunos.TotalPages,
                alunos.HasNext,
                alunos.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(alunos);
        }

        // GET: api/Aluno/5
        [HttpGet("~/api/aluno/{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Alunos/5
        [HttpPut("~/api/aluno/{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            throw new NotImplementedException();
        }

        // POST: api/Alunos
        [HttpPost("~/api/aluno")]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            throw new NotImplementedException();

        }

        // DELETE: api/Alunos/5
        [HttpDelete("~/api/aluno/{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            throw new NotImplementedException();

        }
    }
}
