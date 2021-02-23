using MediatR;
using ApiAlunos.Core.Models;

namespace ApiAlunos.Core.Commands
{
    public class CreateAlunoCommand : IRequest<Result<Aluno>>
    {
        public Aluno Request;
        public CreateAlunoCommand(Aluno request)
        {
            Request = request;
        }
    }
}
