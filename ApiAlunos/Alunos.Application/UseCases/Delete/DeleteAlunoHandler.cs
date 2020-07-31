using Alunos.Application.Errors;
using Alunos.Domain;
using Alunos.Infra.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alunos.Application.UseCases
{
    public class DeleteAlunoHandler : IRequestHandler<DeleteAluno, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMediator _mediator;

        public DeleteAlunoHandler(AppDbContext context, IAlunoRepository alunoRepository, IMediator mediator)
        {
            _context = context;
            _alunoRepository = alunoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteAluno request, CancellationToken cancellationToken)
        {
            if (request.AlunoId <= 0)
            {
                await _mediator.Publish(new Error($"Id inválido"));
                return false;
            }

            var aluno = await _alunoRepository.GetById(request.AlunoId);

            if (aluno == null)
            {
                await _mediator.Publish(new Error($"Aluno com id {request.AlunoId} não existe"));
                return false;
            }

            await _alunoRepository.Delete(aluno);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
