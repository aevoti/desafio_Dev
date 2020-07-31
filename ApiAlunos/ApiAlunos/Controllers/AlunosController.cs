using Alunos.Application.Errors;
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
    public class AlunosController : ApiController
    {
        private readonly IMediator _mediator;

        public AlunosController(INotificationHandler<Error> errors, IMediator mediator)
            : base(errors)
        {
            _mediator = mediator;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<IActionResult> GetAlunos([FromQuery] string filter,
            [FromQuery] string sortType, [FromQuery] int pageSize = 10, [FromQuery] int page = 0)
        {
            var request = new GetAlunos
            {
                Filter = filter,
                SortType = SortTypeUtil.FromString(sortType),
                Page = page,
                PageSize = pageSize
            };

            return Response(await _mediator.Send(request));
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAluno(int id)
        {
            var aluno = await _mediator.Send(new GetAlunoById(id));

            if (aluno == null)
            {
                return NotFound();
            }

            return Response(aluno);
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

            return Response();
        }

        // POST: api/Alunos
        [HttpPost]
        public async Task<IActionResult> PostAluno(RegisterAluno request)
        {
            await _mediator.Send(request);

            return Response();
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            await _mediator.Send(new DeleteAluno(id));

            return Response();
        }
    }
}
