using ApiAlunos.Domain.Interfaces.Service;
using System.Collections.Generic;
using ApiAlunos.Domain.Interfaces.Repository;

namespace ApiAlunos.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository) 
        {
            _repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public T Remove(T entity)
        {
            return _repository.Remove(entity);
        }
    }
}
