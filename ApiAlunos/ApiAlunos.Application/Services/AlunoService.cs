using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAlunos.Application.DTOs;
using ApiAlunos.Application.Extensions;
using ApiAlunos.Application.Filters;
using ApiAlunos.Domain.Models;
using ApiAlunos.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiAlunos.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAlunoDTO>> GetAlunos(GetAlunosFilter filter)
        {
            var alunos = _alunoRepository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(filter?.Nome), x => x.Nome.ToLower().Contains(filter.Nome.ToLower()));
            return await _mapper.ProjectTo<GetAlunoDTO>(alunos)
                .ToListAsync();
        }

        public async Task<GetAlunoDTO> GetAlunoById(int id)
        {
            var aluno = await _alunoRepository.GetById(id);
            return _mapper.Map<GetAlunoDTO>(aluno);
        }

        public async Task<GetAlunoDTO> CreateAluno(InsertAlunoDTO aluno)
        {
            var alunoMapped = _alunoRepository.Create(_mapper.Map<Aluno>(aluno));
            await _alunoRepository.SaveChangesAsync();

            return _mapper.Map<GetAlunoDTO>(alunoMapped);
        }

        public async Task<GetAlunoDTO> UpdateAluno(int id, UpdateAlunoDTO alunoAtualizado)
        {
            var alunoOriginal = await _alunoRepository.GetById(id);
            if (alunoOriginal == null) return null;

            alunoOriginal.Nome = alunoAtualizado.Nome;

            alunoOriginal.Email = alunoAtualizado.Email;

            _alunoRepository.Update(alunoOriginal);

            await _alunoRepository.SaveChangesAsync();

            return _mapper.Map<GetAlunoDTO>(alunoOriginal);
        }

        public async Task<bool> DeleteAluno(int id)
        {
            await _alunoRepository.Delete(id);
            return await _alunoRepository.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _alunoRepository.Dispose();
        }
    }
}