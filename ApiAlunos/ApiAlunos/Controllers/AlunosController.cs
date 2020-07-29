using ApiAlunos.Context;
using ApiAlunos.Interfaces;
using ApiAlunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoAppService _alunoAppService;

        public AlunosController(IAlunoAppService alunoAppService)
        {
            _alunoAppService = alunoAppService;
        }

        /// <summary>
        /// Retorna todos os Alunos do banco de dados
        /// </summary>
        /// <returns></returns>
        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> ObterAlunos()
        {
            return await Ok(_alunoAppService.ObterTodosAlunos());
        }

        /// <summary>
        /// Retorna um Aluno, através do ID
        /// </summary>
        /// <param name="AlunoId">AlunoId</param>
        /// <returns></returns>
        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> ObterAlunoPorId(int id)
        {
            var aluno = await _alunoAppService.ObterAlunoPorId(id);

            if (aluno == null) return NotFound();
            else return Ok(aluno);
        }

        /// <summary>
        /// Atualiza um Aluno existente no banco de dados
        /// </summary>
        /// <param name="Aluno">Aluno</param>
        /// <returns></returns>
        // PUT: api/Alunos/5
        [HttpPut]
        public async Task<ActionResult<Aluno>> AtualizarAluno([FromBody] Aluno aluno)
        {
            return Ok(await _alunoAppService.AtualizarAluno(aluno));
        }

        /// <summary>
        /// Insere aluno no banco de dados
        /// </summary>
        /// <param name="Aluno">Aluno</param>
        /// <returns></returns>
        // POST: api/Alunos
        [HttpPost]
        public async Task<ActionResult<Aluno>> InserirAluno([FromBody] Aluno aluno)
        {
            return Ok(await _alunoAppService.CriarAluno(aluno));
        }

        /// <summary>
        /// Remove do banco de dados um aluno, através do AlunoId
        /// </summary>
        /// <param name="AlunoId">AlunoId</param>
        /// <returns></returns>
        // POST: api/Alunos
        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeletarAluno(int id)
        {
            var alunoExcluido = await _alunoAppService.DeletarAluno(id);
            if (alunoExcluido) return NoContent();
            else return NotFound();
        }
    }
}
