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
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(e => e.Nome)
                .NotNull()
                .NotEmpty()
                .Length(5, 100);

            When(e => !string.IsNullOrEmpty(e.Nome), () =>
            {
                RuleFor(e => e.Nome)
                    .Must(nome => nome.Split(' ').Length >= 2);

            });
        }
    }
}
