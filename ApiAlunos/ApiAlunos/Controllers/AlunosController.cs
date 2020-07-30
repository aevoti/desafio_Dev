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
        /// <summary>
        /// Recupera todos alunos
        /// </summary>
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
        [HttpGet("{id}", Name = "AlunoById")]
        public IActionResult GetAluno(int id)
        {
            var aluno = _repo.Aluno.GetAlunoById(id);

            return Ok(aluno);
        }

        // POST: api/Alunos
        [HttpPost]
        public IActionResult PostAluno(Aluno aluno)
        {
            if (aluno == null)
            {
                return BadRequest("O Objeto aluno é nulo");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Aluno.CreateAluno(aluno);
            _repo.Save();

            return CreatedAtRoute("AlunoById", new { id = aluno.AlunoId }, aluno);
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, Aluno aluno)
        {
            if (aluno == null)
            {
                return BadRequest("O Objeto aluno é nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }

            var dbAluno = _repo.Aluno.GetAlunoById(id);
            if(dbAluno ==  null)
            {
                return NotFound();
            }

            _repo.Aluno.UpdateAluno(dbAluno, aluno);
            _repo.Save();

            return Ok(dbAluno);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            var aluno = _repo.Aluno.GetAlunoById(id);

            if(aluno == null)
            {
                return NotFound();
            }

            _repo.Aluno.DeleteAluno(aluno);
            _repo.Save();

            return NoContent();
        }
    }
}
