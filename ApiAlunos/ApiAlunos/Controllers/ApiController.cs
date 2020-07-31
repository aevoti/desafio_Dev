using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alunos.Application.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAlunos.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly ErrorHandler _errors;

        protected ApiController(INotificationHandler<Error> errors)
        {
            _errors = (ErrorHandler) errors;
        }

        protected IEnumerable<Error> Notifications => _errors.GetErrors();

        protected bool IsValidOperation()
        {
            return (!_errors.HasErrors());
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _errors.GetErrors().Select(n => n.Message)
            });
        }
    }
}
