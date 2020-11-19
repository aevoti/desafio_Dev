using ApiAlunos.Domain.Models;
using ApiAlunos.Domain.Interfaces.Repository;
using ApiAlunos.Infra.Data.Context;

namespace ApiAlunos.Infra.Data.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository 
    {
        public AlunoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}