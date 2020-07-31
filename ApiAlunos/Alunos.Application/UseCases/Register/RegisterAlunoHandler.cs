using Alunos.Application.Errors;
using Alunos.Application.Util;
using Alunos.Domain;
using Alunos.Infra.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alunos.Application.UseCases
{
    public class RegisterAlunoHandler : IRequestHandler<RegisterAluno, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMediator _mediator;

        public RegisterAlunoHandler(AppDbContext context, IAlunoRepository alunoRepository, IMediator mediator)
        {
            _context = context;
            _alunoRepository = alunoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(RegisterAluno request, CancellationToken cancellationToken)
        {
            var validationResult = new RegisterAlunoValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                validationResult.PublishErrors(_mediator);
                return false;
            }

            var aluno = new Aluno(request.Email, request.Nome);

            var alunoComMesmoEmail = await _alunoRepository.GetByEmail(request.Email);

            if (alunoComMesmoEmail != null && alunoComMesmoEmail != aluno)
            {
                await _mediator.Publish(new Error($"Já existe um aluno com o e-mail {request.Email}"));
                return false;
            }


            await _alunoRepository.Add(aluno);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
