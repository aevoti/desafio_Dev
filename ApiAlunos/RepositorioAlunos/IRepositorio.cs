using System.Threading.Tasks;
using DominioAlunos;

namespace RepositorioAlunos
{
    public interface IRepositorio
    {
        void Adicionar<TEntity>(TEntity entity) where TEntity : class;
        void Atualizar<TEntity>(TEntity entity) where TEntity : class;
        void Remover<TEntity>(TEntity entity) where TEntity : class;
        Task<Aluno[]> ObterTodos();
        Task<Aluno> ObterPorId(int id);
        Task<bool> SaveChanges();
    }
}