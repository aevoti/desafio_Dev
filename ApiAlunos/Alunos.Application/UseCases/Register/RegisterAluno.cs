using MediatR;

namespace Alunos.Application.UseCases
{
    public class RegisterAluno : IRequest<bool>
    {
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
