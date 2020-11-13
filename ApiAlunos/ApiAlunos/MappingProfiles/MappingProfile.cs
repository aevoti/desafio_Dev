using ApiAlunos.DTOs;
using ApiAlunos.Models;
using AutoMapper;

namespace ApiAlunos.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aluno, GetAlunoDTO>();
            CreateMap<InsertAlunoDTO, Aluno>();
            CreateMap<UpdateAlunoDTO, Aluno>();
        }
    }
}
