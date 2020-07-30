using Alunos.Application.ViewModels;
using Alunos.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
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
            var query = _alunoRepository.GetAlunos();

            if (!string.IsNullOrEmpty(request.Filter))
            {
                var filter = request.Filter.Trim().ToLower();

                var isNumeric = int.TryParse(request.Filter, out _);

                if (isNumeric)
                {
                    query = query.Where(a => Convert.ToString(a.AlunoId).StartsWith(request.Filter));
                }
                else
                {
                    query = query.Where(a =>
                        a.Nome.ToLower().Contains(filter)
                    );
                }
            }

            return (await query.ToListAsync())
                .Select(a => _mapper.Map<AlunoViewModel>(a));
        }
    }
}
