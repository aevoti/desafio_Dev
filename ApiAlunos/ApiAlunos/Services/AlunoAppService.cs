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

        public AlunoAppService() { }

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
            try
            {
                if (string.IsNullOrEmpty(aluno.Email) || string.IsNullOrEmpty(aluno.Nome))
                {
                    throw new Exception("Todos os campos são obrigatórios!");
                }

                var alunoCriado = _alunoRepository.Create(aluno);
                await _alunoRepository.SaveChangesAsync();
                return alunoCriado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> AtualizarAluno(Aluno aluno)
        {
            try
            {
                var alunoExiste = await ObterAlunoPorId(aluno.AlunoId);
                if (alunoExiste != null)
                {
                    if (string.IsNullOrEmpty(alunoExiste.Email) || string.IsNullOrEmpty(alunoExiste.Nome))
                    {
                        throw new Exception("Todos os campos são obrigatórios!");
                    }
                    _alunoRepository.Update(aluno);
                    return await _alunoRepository.SaveChangesAsync() > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<bool> DeletarAluno(int id)
        {
            try
            {
                await _alunoRepository.Delete(id);
                return await _alunoRepository.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("IdAluno para exclusão inválido!");
            }
            
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
