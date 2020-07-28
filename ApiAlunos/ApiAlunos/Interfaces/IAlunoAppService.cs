using ApiAlunos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Interfaces
{
    public interface IAlunoAppService: IDisposable
    {
        public Task<List<Aluno>> ObterTodosAlunos();

        public Task<Aluno> ObterAlunoPorId(Guid id);

        public Task<Aluno> CriarAluno(Aluno aluno);

        public Task<Aluno> AtualizarAluno(Aluno aluno);

        public Task<bool> DeletarAluno(Guid id);

    }
}
