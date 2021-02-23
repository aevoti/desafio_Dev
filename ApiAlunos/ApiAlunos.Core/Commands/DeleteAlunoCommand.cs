using MediatR;

namespace ApiAlunos.Core.Commands
{
    public class DeleteAlunoCommand : IRequest<Result>
    {
        public int Id;
        public DeleteAlunoCommand(int id)
        {
            Id = id;
        }
    }
}
