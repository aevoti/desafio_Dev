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

        public RegisterAlunoHandler(AppDbContext context, IAlunoRepository alunoRepository)
        {
            _context = context;
            _alunoRepository = alunoRepository;
        }

        public async Task<bool> Handle(RegisterAluno request, CancellationToken cancellationToken)
        {
            var validationResult = new RegisterAlunoValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                // Todo: domain notification
                return false;
            }

            var aluno = new Aluno(request.Email, request.Nome);

            var alunoComMesmoEmail = await _alunoRepository.GetByEmail(request.Email);

            if (alunoComMesmoEmail != null && alunoComMesmoEmail != aluno)
            {
                // Todo: domain notification
                return false;
            }


            await _alunoRepository.Add(aluno);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
