using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using ApiAlunos.Core.Models;
using ApiAlunos.Core.Queries;
using ApiAlunos.Core.Commands;

namespace ApiAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlunosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            var command = new GetAlunoQuery();
            var retorno = await _mediator.Send(command);

            return Ok(retorno);
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var command = new GetAlunoByIdQuery(id);
            var retorno = await _mediator.Send(command);

            return Ok(retorno);
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(Aluno aluno)
        {
            var command = new UpdateAlunoCommand(aluno);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // POST: api/Alunos
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            var command = new CreateAlunoCommand(aluno);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            var command = new DeleteAlunoCommand(id);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
