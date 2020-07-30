using Alunos.Domain;
using Alunos.Application.UseCases.Update;
using Alunos.Infra.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alunos.Application.UseCases
{
    public class UpdateAlunoHandler : IRequestHandler<UpdateAluno, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAlunoRepository _alunoRepository;

        public UpdateAlunoHandler(AppDbContext context, IAlunoRepository alunoRepository)
        {
            _context = context;
            _alunoRepository = alunoRepository;
        }

        public async Task<bool> Handle(UpdateAluno request, CancellationToken cancellationToken)
        {
            var validationResult = new UpdateAlunoValidator().Validate(request);

            if (!validationResult.IsValid)
            {
                // Todo: domain notification
                return false;
            }

            var aluno = await _alunoRepository.GetById(request.AlunoId);

            if (aluno == null)
            {
                // Todo: domain notification
                return false;
            }

            var alunoComMesmoEmail = await _alunoRepository.GetByEmail(request.Email);

            if (alunoComMesmoEmail != null && alunoComMesmoEmail != aluno)
            {
                // Todo: domain notification
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
