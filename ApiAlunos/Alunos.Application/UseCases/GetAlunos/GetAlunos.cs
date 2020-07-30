using Alunos.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.UseCases
{
    public class GetAlunos : IRequest<IEnumerable<AlunoViewModel>>
    {
    }
}
