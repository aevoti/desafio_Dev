using MediatR;
using ApiAlunos.Core.Models;
using System.Threading.Tasks;
using System.Threading;
using ApiAlunos.Core.Interfaces;
using System;

namespace ApiAlunos.Core.Commands.Handler
{
    public class UpdateAlunoCommandHandler : IRequestHandler<UpdateAlunoCommand, Result<Aluno>>
    {
        private readonly IAlunosRepository _alunosRepository;
        public UpdateAlunoCommandHandler(
            IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        public async Task<Result<Aluno>> Handle(UpdateAlunoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<Aluno>();

                if (!_alunosRepository.AlunoExists(command.Request.AlunoId))
                {
                    result.WithError("");
                    return result;
                }

                var _aluno = command.Request;

                if (await _alunosRepository.UpdateAsync(_aluno))
                    result.Value = _aluno;

                return result;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
