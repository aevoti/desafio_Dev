using MediatR;
using ApiAlunos.Core.Models;

namespace ApiAlunos.Core.Commands
{
    public class UpdateAlunoCommand : IRequest<Result<Aluno>>
    {
        public Aluno Request;
        public UpdateAlunoCommand(Aluno request)
        {
            Request = request;
        }
    }
}
