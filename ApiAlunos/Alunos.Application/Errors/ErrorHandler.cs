using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alunos.Application.Errors
{
    public class ErrorHandler : INotificationHandler<Error>
    {
        private List<Error> _error;

        public ErrorHandler()
        {
            _error = new List<Error>();
        }

        public Task Handle(Error message, CancellationToken cancellationToken)
        {
            _error.Add(message);

            return Task.CompletedTask;
        }

        public virtual List<Error> GetErrors()
        {
            return _error;
        }

        public virtual bool HasErrors()
        {
            return GetErrors().Any();
        }

        public void Dispose()
        {
            _error = new List<Error>();
        }
    }
}
