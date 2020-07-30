using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.UseCases.Update
{
    public class UpdateAlunoValidator : AbstractValidator<UpdateAluno>
    {
        public UpdateAlunoValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(e => e.Nome)
                .NotEmpty()
                .NotNull()
                .Must(nome => nome.Split(' ').Length >= 2);

            RuleFor(e => e.AlunoId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
