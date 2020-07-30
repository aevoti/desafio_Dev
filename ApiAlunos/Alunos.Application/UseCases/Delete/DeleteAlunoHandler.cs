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

        public DeleteAlunoHandler(AppDbContext context, IAlunoRepository alunoRepository)
        {
            _context = context;
            _alunoRepository = alunoRepository;
        }

        public async Task<bool> Handle(DeleteAluno request, CancellationToken cancellationToken)
        {
            if (request.AlunoId <= 0)
            {
                return false;
            }

            var aluno = await _alunoRepository.GetById(request.AlunoId);

            if (aluno == null)
            {
                // Todo: domain notification
                return false;
            }

            await _alunoRepository.Delete(aluno);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
