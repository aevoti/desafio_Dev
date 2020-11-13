﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAlunos.DTOs;
using ApiAlunos.Filters;

namespace ApiAlunos.Services
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
