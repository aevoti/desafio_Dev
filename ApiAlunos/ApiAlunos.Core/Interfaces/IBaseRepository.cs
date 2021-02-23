using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAlunos.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        void DetachLocal(Func<TEntity, bool> predicate);
    }
}
