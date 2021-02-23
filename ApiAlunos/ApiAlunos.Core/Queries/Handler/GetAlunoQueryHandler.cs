using MediatR;
using System.Collections.Generic;
using ApiAlunos.Core.Models;
using System.Threading.Tasks;
using System.Threading;
using ApiAlunos.Core.Interfaces;
using System.Linq;

namespace ApiAlunos.Core.Queries.Handler
{
    public class GetAlunoQueryHandler : IRequestHandler<GetAlunoQuery, Result<IEnumerable<Aluno>>>
    {
        private readonly IAlunosRepository _alunosRepository;

        public GetAlunoQueryHandler(IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        public async Task<Result<IEnumerable<Aluno>>> Handle(GetAlunoQuery request, CancellationToken cancellationToken)
        {
            var result = new Result<IEnumerable<Aluno>>();

            var retorno = await _alunosRepository.Get();

            result.Count = retorno.Count();
            result.Value = retorno;
            return result;
        }
    }
}
