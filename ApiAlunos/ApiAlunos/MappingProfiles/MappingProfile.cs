using ApiAlunos.DTOs;
using ApiAlunos.Models;
using AutoMapper;

namespace ApiAlunos.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aluno, GetAlunoDTO>().ReverseMap();
            CreateMap<InserirAlunoDTO, Aluno>();
            CreateMap<AtualizarAlunoDTO, Aluno>();
        }
    }
}
