
using Contracts;
using Entities.Context;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IAlunoRepository _aluno;

        public IAlunoRepository Aluno
        {
            get
            {
                if(_aluno == null)
                {
                    _aluno = new AlunoRepository(_repoContext);
                }

                return _aluno;
            }
        }

        public RepositoryWrapper(RepositoryContext appDbContext)
        {
            _repoContext = appDbContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
