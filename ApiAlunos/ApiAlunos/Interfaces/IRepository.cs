using ApiAlunos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiAlunos.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(TEntity entity);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
