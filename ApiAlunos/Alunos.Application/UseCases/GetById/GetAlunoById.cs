using Alunos.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.UseCases
{
    public class GetAlunoById : IRequest<AlunoViewModel>
    {
        public GetAlunoById(int id)
        {
            AlunoId = id;
        }

        public int AlunoId { get; set; }
    }
}
