using MediatR;
using System.Collections.Generic;
using ApiAlunos.Core.Models;

namespace ApiAlunos.Core.Queries
{
    public class GetAlunoQuery : IRequest<Result<IEnumerable<Aluno>>>
    {
        public GetAlunoQuery()
        {
        }
    }
}
