using Alunos.Application.ViewModels;
using Alunos.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alunos.Application.UseCases
{
    public class GetAlunoByIdHandler : IRequestHandler<GetAlunoById, AlunoViewModel>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public GetAlunoByIdHandler(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<AlunoViewModel> Handle(GetAlunoById request, CancellationToken cancellationToken)
        {
            var aluno = (await _alunoRepository.GetById(request.AlunoId));
            return _mapper.Map<AlunoViewModel>(aluno);
        }
    }
}
