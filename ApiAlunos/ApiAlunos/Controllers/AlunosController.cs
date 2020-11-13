using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAlunos.Context;
using ApiAlunos.DTOs;
using ApiAlunos.Filters;
using ApiAlunos.Models;
using ApiAlunos.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        /// <summary>
        /// Retorna todos os alunos cadastrados.
        /// </summary>
        /// <param name="filter">Filtro opcional a ser aplicado à busca.</param>
        /// <returns>A lista de alunos cadastrados de acordo com o filtro informado.</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<GetAlunoDTO>>> GetAlunos([FromQuery] GetAlunosFilter filter)
        {
            return Ok(await _alunoService.GetAlunos(filter));
        }

        /// <summary>
        /// Retorna o aluno com o id informado.
        /// </summary>
        /// <param name="id">Id do aluno.</param>
        /// <returns>O aluno com id informado.</returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<GetAlunoDTO>> GetAluno(int id)
        {
            var aluno = await _alunoService.GetAlunoById(id);

            if (aluno == null) return NotFound();

            return Ok(aluno);
        }

        /// <summary>
        /// Atualiza o aluno que tem o id informado.
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <param name="aluno">Dados do aluno</param>
        /// <response code="204">Retorna sucesso na atualização.</response>
        /// <response code="400">Retorna os erros de validação.</response>   
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> PutAluno(int id, [FromBody] UpdateAlunoDTO aluno)
        {

            await _alunoService.UpdateAluno(id, aluno);

            return NoContent();
        }

        /// <summary>
        /// Insere um novo aluno.
        /// </summary>
        /// <param name="aluno">Dados do aluno.</param>
        /// <response code="201">Retorna o aluno criado</response>
        /// <response code="400">Retorna os erros de validação</response>   
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<GetAlunoDTO>> PostAluno(InsertAlunoDTO aluno)
        {
            var novoAluno = await _alunoService.CreateAluno(aluno);

            return CreatedAtAction("GetAluno", new {id = novoAluno.Id}, novoAluno);
        }

        /// <summary>
        /// Deleta o aluno que tem o id informado.
        /// </summary>
        /// <param name="id">Id do aluno.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var deletado = await _alunoService.DeleteAluno(id);
            if (deletado)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}