using Contracts;
using Entities.Context;
using Entities.Helpers;
using Entities.Models;
using System.Linq;

namespace Repository
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(RepositoryContext repoContext) : base(repoContext)
        { 
        }

        public PagedList<Aluno> GetAlunos(AlunoParameters parameters)
        {
            var alunos = FindAll();

            SearchByName(ref alunos, parameters.Nome);

            return PagedList<Aluno>.ToPagedList(alunos, parameters.PageNumber, parameters.PageSize);

        }

        public Aluno GetAlunoById(int alunoId)
        {
            return FindByCondition(aluno => aluno.AlunoId == alunoId)
                .DefaultIfEmpty(new Aluno())
                .FirstOrDefault();
        }

        private void SearchByName(ref IQueryable<Aluno> alunos, string nome)
        {
            if (!alunos.Any() || string.IsNullOrWhiteSpace(nome))
                return;

            alunos = alunos.Where(o => o.Nome.ToLower().Contains(nome.Trim().ToLower()));
        }
    }
}
