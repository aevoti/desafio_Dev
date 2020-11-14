using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAlunos.Application.DTOs;
using ApiAlunos.Application.Filters;

namespace ApiAlunos.Application.Services
{
    public interface IAlunoService : IDisposable
    {
        #region Aluno Methods

        public Task<List<GetAlunoDTO>> GetAlunos(GetAlunosFilter filter);

        public Task<GetAlunoDTO> GetAlunoById(int id);

        public Task<GetAlunoDTO> CreateAluno(InsertAlunoDTO aluno);

        public Task<GetAlunoDTO> UpdateAluno(int id, UpdateAlunoDTO alunoAtualizado);

        public Task<bool> DeleteAluno(int id);

        #endregion
    }
}