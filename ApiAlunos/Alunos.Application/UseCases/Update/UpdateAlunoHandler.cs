using Alunos.Domain;
using Alunos.Application.UseCases.Update;
using Alunos.Infra.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Alunos.Application.Util;
using Alunos.Application.Errors;

namespace Alunos.Application.UseCases
{
    public class UpdateAlunoHandler : IRequestHandler<UpdateAluno, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMediator _mediator;

        public UpdateAlunoHandler(AppDbContext context, IAlunoRepository alunoRepository, IMediator mediator)
        {
            _context = context;
            _alunoRepository = alunoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateAluno request, CancellationToken cancellationToken)
        {
            var validationResult = new UpdateAlunoValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                validationResult.PublishErrors(_mediator);
                return false;
            }

            var aluno = await _alunoRepository.GetById(request.AlunoId);

            if (aluno == null)
            {
                await _mediator.Publish(new Error($"Aluno com id {request.AlunoId} não existe"));
                return false;
            }

            var alunoComMesmoEmail = await _alunoRepository.GetByEmail(request.Email);

            if (alunoComMesmoEmail != null && alunoComMesmoEmail != aluno)
            {
                await _mediator.Publish(new Error($"Já existe um aluno com o e-mail {request.Email}"));
                return false;
            }

            aluno.UpdateNome(request.Nome);
            aluno.UpdateEmail(request.Email);

            await _alunoRepository.Update(aluno);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
