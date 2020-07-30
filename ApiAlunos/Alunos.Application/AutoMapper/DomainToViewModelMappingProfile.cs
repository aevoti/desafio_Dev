using Alunos.Application.ViewModels;
using Alunos.Domain;
using AutoMapper;

namespace Alunos.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Aluno, AlunoViewModel>();
        }
    }
}
