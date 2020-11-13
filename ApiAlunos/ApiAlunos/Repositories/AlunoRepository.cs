using ApiAlunos.Context;
using ApiAlunos.Models;

namespace ApiAlunos.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AlunoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
