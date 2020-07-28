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
        private readonly IAlunoRepository _alunoRepo;

        public AlunosController(IAlunoRepository alunoRepo)
        {
            this._alunoRepo = alunoRepo;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                return await _alunoRepo.ObterTodos();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            try
            {
                var aluno = await _alunoRepo.ObterPorId(id.Value);

                if (aluno == null)
                {
                    return NotFound();
                }

                return aluno;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("aluno/{nome}")]
        public async Task<ActionResult<Aluno>> GetAlunoByName(string nome)
        {
            try
            {
                var aluno = (await _alunoRepo.Buscar(x => x.Nome == nome)).First();

                if (aluno == null)
                {
                    return NotFound();
                }

                return aluno;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }


            try
            {
                await _alunoRepo.Atualizar(aluno);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AlunoExistsAsync(id))
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
        public async Task<ActionResult> PostAluno(Aluno aluno)
        {
            try
            {
                await _alunoRepo.Adicionar(aluno);
                return CreatedAtAction("GetAluno", new { id = aluno.AlunoId }, aluno);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            try
            {
                var aluno = await _alunoRepo.ObterPorId(id.Value);
                if (aluno == null)
                {
                    return NotFound();
                }

                await _alunoRepo.Remover(aluno);
                return aluno;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        private async Task<bool> AlunoExistsAsync(int id)
        {
            var aluno = await _alunoRepo.ObterPorId(id);
            return aluno != null;
        }
    }
}
