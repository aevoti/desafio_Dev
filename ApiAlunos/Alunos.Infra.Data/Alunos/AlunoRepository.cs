using Alunos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Alunos.Infra.Data.Alunos
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Aluno> _dbSet;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Aluno>();
        }

        public async Task Add(Aluno aluno)
        {
            await _dbSet.AddAsync(aluno);
        }

        public async Task Delete(Aluno aluno)
        {
            await Task.Run(() => _dbSet.Remove(aluno));
        }

        public IQueryable<Aluno> GetAlunos()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Aluno> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<Aluno> GetByEmail(string alunoEmail)
        {
            return _dbSet.FirstOrDefaultAsync(a => a.Email == alunoEmail);
        }

        public async Task Update(Aluno aluno)
        {
            await Task.Run(() => _dbSet.Update(aluno));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
