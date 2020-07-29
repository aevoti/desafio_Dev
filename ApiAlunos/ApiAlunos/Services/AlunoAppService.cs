using ApiAlunos.Interfaces;
using ApiAlunos.Models;
using ApiAlunos.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoAppService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<List<Aluno>> ObterTodosAlunos()
        {
            var alunos = await _alunoRepository.GetAll();
            return alunos;
        }

        public async Task<Aluno> ObterAlunoPorId(int id)
        {
            return await _alunoRepository.GetById(id);
        }

        public async Task<Aluno> CriarAluno(Aluno aluno)
        {
            var alunoCriado = _alunoRepository.Create(aluno);
            await _alunoRepository.SaveChangesAsync();
            return alunoCriado;
        }

        public async Task<Aluno> AtualizarAluno(Aluno aluno)
        {
            var alunoAtualizado = _alunoRepository.Update(aluno);
            await _alunoRepository.SaveChangesAsync();
            return alunoAtualizado;
        }

        public async Task<bool> DeletarAluno(int id)
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
            if (disposing)
            {
                _alunoRepository.Dispose();
            }
        }

    }
}
