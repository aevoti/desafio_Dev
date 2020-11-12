using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.UseCases
{
    public class DeleteAluno : IRequest<bool>
    {
        public DeleteAluno(int id)
        {
            AlunoId = id;
        }

        public int AlunoId { get; set; }
    }
}
