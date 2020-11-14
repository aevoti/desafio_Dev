using ApiAlunos.Domain.Models;
using ApiAlunos.Domain.Repositories;
using ApiAlunos.Infrastructure.Context;

namespace ApiAlunos.Infrastructure.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AlunoDbContext dbContext) : base(dbContext)
        {
        }
    }
}