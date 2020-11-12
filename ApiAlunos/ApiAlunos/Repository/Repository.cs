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
            try
            {
                return await dbSet.AsNoTracking().Where(predicate).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> ObterPorId(int id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);
                if (entity != null)
                    dbContext.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<TEntity>> ObterTodos()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task Adicionar(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
                await SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task Atualizar(TEntity entity)
        {
            try
            {
                dbContext.Entry(entity).State = EntityState.Detached;
                dbSet.Update(entity);
                await SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task Remover(TEntity entity)
        {
            try
            {
                dbSet.Remove(entity);
                await SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<int> SaveChanges()
        {
            try
            {
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
