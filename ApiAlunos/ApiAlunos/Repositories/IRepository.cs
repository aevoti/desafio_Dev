using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        Task Delete(int id);

        Task<int> SaveChangesAsync();
    }
}