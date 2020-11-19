using ApiAlunos.Domain.Models;
using ApiAlunos.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ApiAlunos.ViewModels;

namespace ApiAlunos.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : Controller
    {
        private IAlunoService _alunoService;
        private IMapper _mapper;

        public AlunosController(IAlunoService alunoService, IMapper mapper)
        {
            _alunoService = alunoService;
            _mapper = mapper;
        }

        // GET: api/Alunos
        /// <summary>
        /// Busca todos os alunos
        /// </summary>
        /// <response code="200">Buscou alunos com sucesso</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAlunos()
        {
            return Json(_mapper.Map<IEnumerable<AlunoViewModel>>(_alunoService.GetAll()));
        }

        // GET: api/Alunos/5
        /// <summary>
        /// Busca um aluno pelo id
        /// </summary>
        /// <response code="200">Encontrou aluno com sucesso</response>
        /// <response code="404">Não encontrou o aluno</response> 
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoViewModel>> GetAluno(int id)
        {
            var aluno = _alunoService.Get(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Json(_mapper.Map<AlunoViewModel>(aluno));
        }

        // PUT: api/Alunos/5
        /// <summary>
        /// Atualiza um aluno
        /// </summary>
        /// <response code="200">Atualizou aluno com sucesso</response>
        /// <response code="400">Id da Url diferente do Id do objeto</response> 
        /// <response code="404">Não achou o aluno que se deseja atualizar</response> 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, AlunoViewModel alunoVM)
        {
            if (id != alunoVM.AlunoId)
            {
                return BadRequest();
            }

            try
            {
                _alunoService.Update(_mapper.Map<Aluno>(alunoVM));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_alunoService.AlunoExists(id))
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
        /// <summary>
        /// Cria um aluno
        /// </summary>
        /// <response code="201">Criou aluno com sucesso</response>
        [HttpPost]
        public async Task<ActionResult<AlunoViewModel>> PostAluno(AlunoViewModel alunoVM)
        {
            var aluno = _alunoService.Add(_mapper.Map<Aluno>(alunoVM));

            return CreatedAtAction("GetAluno", new { id = aluno.AlunoId }, _mapper.Map<AlunoViewModel>(aluno));
        }

        // DELETE: api/Alunos/5
        /// <summary>
        /// Deleta um aluno
        /// </summary>
        /// <response code="200">Deletou aluno com sucesso</response>
        /// <response code="404">Não achou o aluno que se deseja deletar</response> 
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoViewModel>> DeleteAluno(int id)
        {
            var aluno = _alunoService.Get(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return Json(_mapper.Map<AlunoViewModel>(_alunoService.Remove(aluno)));
        }
    }
}
