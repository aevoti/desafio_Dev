using ApiAlunos.Application.DTOs;
using ApiAlunos.Domain.Models;
using AutoMapper;

namespace ApiAlunos.Application.MappingProfiles
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