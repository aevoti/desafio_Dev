using ApiAlunos.Context;
using ApiAlunos.Interfaces;
using ApiAlunos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiAlunos.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        protected Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> ObterPorId(int id)
        {
            var entity = await dbSet.FindAsync(id);
            dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }
        public async Task Remover(TEntity entity)
        {
            dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
