using Alunos.Application.ViewModels;
using Alunos.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alunos.Application.UseCases
{
    public class GetAlunosHandler : IRequestHandler<GetAlunos, PaginatedList<AlunoViewModel>>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public GetAlunosHandler(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<AlunoViewModel>> Handle(GetAlunos request, CancellationToken cancellationToken)
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

            switch (request.SortType)
            {
                case SortType.ORDER_BY_ID_DEC:
                    query = query.OrderByDescending(a => a.AlunoId);
                    break;
                case SortType.ORDER_BY_NOME_ASC:
                    query = query.OrderBy(a => a.Nome);
                    break;
                case SortType.ORDER_BY_NOME_DEC:
                    query = query.OrderByDescending(a => a.Nome);
                    break;
            }

            var count = await query.CountAsync();

            query = query.Skip(request.PageSize * request.Page)
                .Take(request.PageSize);

           
            return new PaginatedList<AlunoViewModel>() {
                Items = (await query.ToListAsync())
                    .Select(a => _mapper.Map<AlunoViewModel>(a)),
                TotalCount = count,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
