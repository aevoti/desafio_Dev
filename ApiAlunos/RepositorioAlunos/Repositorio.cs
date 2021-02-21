using System.Linq;
using System.Threading.Tasks;
using DominioAlunos;
using Microsoft.EntityFrameworkCore;

namespace RepositorioAlunos
{
    public class Repositorio : IRepositorio
    {
        protected readonly AlunosDbContext _context;

        public Repositorio(AlunosDbContext context)
        {
            _context = context;
        }

        public void Adicionar<TEntity>(TEntity entity) where TEntity : class
        {
          _context.Add(entity);
        }

        public void Atualizar<TEntity>(TEntity entity) where TEntity : class
        {
          _context.Update(entity);
        }

        public async Task<Aluno> ObterPorId(int id)
        {
          IQueryable<Aluno> query = _context.Alunos;

          query = query.Where(n => n.Id == id);

          return await query.FirstOrDefaultAsync();

        }

        public async Task<Aluno[]> ObterTodos()
        {
          IQueryable<Aluno> query = _context.Alunos;

          query = query.OrderBy(n => n.Nome);

          return await query.ToArrayAsync();

        }

        public void Remover<TEntity>(TEntity entity) where TEntity : class
        {
          _context.Remove(entity);
        }

        public async Task<bool> SaveChanges()
        {
          return (await _context.SaveChangesAsync()) > 0;
        }
  }
}