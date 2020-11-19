using ApiAlunos.Domain.Interfaces.Repository;
using ApiAlunos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ApiAlunos.Infra.Data.Repository
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        public DbSet<T> DbSet { get; set; }
        public AppDbContext DbContext { get; set; }

        public BaseRepository(AppDbContext dbContext) 
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public T Add(T entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public T Remove(T entity)
        {
            return DbSet.Remove(entity).Entity;
        }

        public void Dispose()
        {
            DbContext.SaveChanges();

            if (DbContext != null)
            {
                DbContext.Dispose();
                DbContext = null;
            }
        }
    }
}