using MediatR;
using ApiAlunos.Core.Models;
using System.Threading.Tasks;
using System.Threading;
using ApiAlunos.Core.Interfaces;
using System;

namespace ApiAlunos.Core.Commands.Handler
{
    public class CreateAlunoCommandHandler : IRequestHandler<CreateAlunoCommand, Result<Aluno>>
    {
        private readonly IAlunosRepository _alunosRepository;
        public CreateAlunoCommandHandler(
            IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        public async Task<Result<Aluno>> Handle(CreateAlunoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<Aluno>
                {
                    Value = await _alunosRepository.AddAsync(command.Request)
                };

                return result;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
