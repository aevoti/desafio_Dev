using ApiAlunos.Domain.Models;
using ApiAlunos.Domain.Interfaces.Repository;
using ApiAlunos.Infra.Data.Context;
using System.Linq;

namespace ApiAlunos.Infra.Data.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository 
    {
        public AlunoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public bool AlunoExists(int id)
        {
            return DbSet.Any(e => e.AlunoId == id);
        }
    }
}