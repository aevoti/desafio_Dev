using ApiAlunos.Core.Models;
using ApiAlunos.Core.Interfaces;
using System.Linq;

namespace ApiAlunos.Infrastructure.Repositories
{
    public class AlunosRepository : BaseRepository<Aluno>, IAlunosRepository
    {
        private readonly AppDbContext _dbContext;

        public AlunosRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AlunoExists(int id)
        {
            return _dbContext.Alunos.Any(e => e.AlunoId == id);
        }
    }
}
