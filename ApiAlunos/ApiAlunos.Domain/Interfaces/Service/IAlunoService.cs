using ApiAlunos.Domain.Models;

namespace ApiAlunos.Domain.Interfaces.Service
{
    public interface IAlunoService : IBaseService<Aluno>
    {
        bool AlunoExists(int id);
    }
}