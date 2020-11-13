using System;
using System.Linq;
using System.Threading.Tasks;
using ApiAlunos.Context;
using ApiAlunos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAlunos.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected AlunoDbContext Db { get; }

        protected DbSet<TEntity> DbSet { get; }

        public Repository(AlunoDbContext dbContext)
        {
            Db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = Db.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual TEntity Create(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public virtual async Task Delete(int id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));

        }

        public async Task<int> SaveChangesAsync() => await Db.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
        }
    }
}