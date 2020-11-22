using System.Collections.Generic;

namespace ApiAlunos.Domain.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        T Add(T entity);

        void Update(T entity);

        T Remove(T entity);
    }
}