using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ApiAlunos.Core.Interfaces;
using System;

namespace ApiAlunos.Core.Commands.Handler
{
    public class DeleteAlunoCommandHandler : IRequestHandler<DeleteAlunoCommand, Result>
    {
        private readonly IAlunosRepository _alunosRepository;
        public DeleteAlunoCommandHandler(
            IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        public async Task<Result> Handle(DeleteAlunoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result();

                var _aluno = await _alunosRepository.GetById(command.Id);
                if (_aluno == null)
                {
                    result.WithError("");
                    return result;
                }

                await _alunosRepository.DeleteAsync(_aluno);

                return result;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
