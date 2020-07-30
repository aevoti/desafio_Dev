using Alunos.Application.UseCases;
using Alunos.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAlunos()
        {
            return Ok(await _mediator.Send(new GetAlunos()));
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoViewModel>> GetAluno(int id)
        {
            var aluno = await _mediator.Send(new GetAlunoById(id));

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, UpdateAluno request)
        {
            if (id != request.AlunoId)
            {
                return BadRequest();
            }

            await _mediator.Send(request);

            return NoContent();
        }

        // POST: api/Alunos
        [HttpPost]
        public async Task<ActionResult> PostAluno(RegisterAluno request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            await _mediator.Send(new DeleteAluno(id));

            return Ok();
        }
    }
}
