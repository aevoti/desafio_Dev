using MediatR;
using ApiAlunos.Core.Models;
using System.Threading.Tasks;
using System.Threading;
using ApiAlunos.Core.Interfaces;

namespace ApiAlunos.Core.Queries.Handler
{
    public class GetAlunoByIdQueryHandler : IRequestHandler<GetAlunoByIdQuery, Result>
    {
        private readonly IAlunosRepository _alunosRepository;

        public GetAlunoByIdQueryHandler(IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        public async Task<Result> Handle(GetAlunoByIdQuery request, CancellationToken cancellationToken)
        {
            Result<Aluno> result = new Result<Aluno>();

            var aluno = await _alunosRepository.GetById(request.Id);
            if (aluno == null)
            {
                result.WithError("");
                return result;
            }

            result.Value = aluno;

            return result;
        }
    }
}
