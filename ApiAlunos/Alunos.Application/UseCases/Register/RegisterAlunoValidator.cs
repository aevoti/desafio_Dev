using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.UseCases
{
    public class RegisterAlunoValidator : AbstractValidator<RegisterAluno>
    {
        public RegisterAlunoValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(e => e.Nome)
                .NotEmpty()
                .NotNull()
                .Must(nome => nome.Split(' ').Length >= 2);
        }
    }
}
