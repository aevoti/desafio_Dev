using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alunos.Domain
{
    public interface IAlunoRepository : IDisposable
    {
        IQueryable<Aluno> GetAlunos();
        Task<Aluno> GetById(int id);
        Task<Aluno> GetByEmail(string alunoEmail);
        Task Add(Aluno aluno);
        Task Update(Aluno aluno);
        Task Delete(Aluno aluno);
    }
}
