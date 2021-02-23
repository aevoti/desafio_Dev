using MediatR;
using System.Collections.Generic;
using ApiAlunos.Core.Models;

namespace ApiAlunos.Core.Queries
{
    public class GetAlunoByIdQuery : IRequest<Result>
    {
        public int Id;
        public GetAlunoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
