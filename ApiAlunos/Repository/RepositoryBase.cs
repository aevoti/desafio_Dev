using System;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext AppDbContext { get; set; }

        public RepositoryBase(RepositoryContext appDbContext)
        {
            this.AppDbContext = appDbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.AppDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.AppDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.AppDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.AppDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.AppDbContext.Set<T>().Remove(entity);
        }

    }
}
