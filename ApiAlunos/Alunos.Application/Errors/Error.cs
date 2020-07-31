using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.Errors
{
    public class Error : INotification
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
