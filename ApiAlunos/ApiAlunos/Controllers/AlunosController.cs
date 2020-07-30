using Alunos.Application.UseCases;
using Alunos.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AlunosController> _logger;

        public AlunosController(IMediator mediator, ILogger<AlunosController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAlunos([FromQuery] string filter, [FromQuery] string sortType)
        {
            _logger.LogInformation(Request.Headers.ToString());
            return Ok(await _mediator.Send(new GetAlunos { Filter = filter, SortType = SortTypeUtil.FromString(sortType) }));
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
