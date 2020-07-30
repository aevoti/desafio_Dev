using Alunos.Application.ViewModels;
using Alunos.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alunos.Application.UseCases
{
    public class GetAlunosHandler : IRequestHandler<GetAlunos, IEnumerable<AlunoViewModel>>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public GetAlunosHandler(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlunoViewModel>> Handle(GetAlunos request, CancellationToken cancellationToken)
        {
            return (await _alunoRepository.GetAlunos().ToListAsync())
                .Select(a => _mapper.Map<AlunoViewModel>(a));
        }
    }
}
