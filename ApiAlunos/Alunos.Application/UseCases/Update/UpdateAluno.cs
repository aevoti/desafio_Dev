using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.UseCases
{
    public class UpdateAluno : IRequest<bool>
    {
        public int AlunoId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
