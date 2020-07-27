using Entities.Helpers;
using Entities.Models;

namespace Contracts
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        PagedList<Aluno> GetAlunos(AlunoParameters parameters);
        Aluno GetAlunoById(int alunoId);
        void CreateAluno(Aluno aluno);
        void UpdateAluno(Aluno dbAluno, Aluno aluno);
        void DeleteAluno(Aluno aluno);
    }
}
