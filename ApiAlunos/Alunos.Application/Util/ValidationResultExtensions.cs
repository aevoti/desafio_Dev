using Alunos.Application.Errors;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.Util
{
    public static class ValidationResultExtensions
    {
        public static void PublishErrors(this ValidationResult result, IMediator mediator)
        {
            foreach (var error in result.Errors)
                mediator.Publish(new Error(error.ErrorMessage));
        }
    }
}
