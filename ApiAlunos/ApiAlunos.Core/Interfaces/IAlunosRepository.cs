using ApiAlunos.Core.Models;

namespace ApiAlunos.Core.Interfaces
{
    public interface IAlunosRepository : IBaseRepository<Aluno>
    {
        bool AlunoExists(int id);
    }
}
