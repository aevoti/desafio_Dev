using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Repositorio
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(Guid id);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        Task Delete(Guid id);

        Task<int> SaveChangesAsync();
    }
}
