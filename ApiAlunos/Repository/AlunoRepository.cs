using Contracts;
using Entities.Context;
using Entities.Extensions;
using Entities.Helpers;
using Entities.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

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

            ApplySort(ref alunos, parameters.OrderBy);

            return PagedList<Aluno>.ToPagedList(alunos, parameters.PageNumber, parameters.PageSize);

        }

        public Aluno GetAlunoById(int alunoId)
        {
            return FindByCondition(aluno => aluno.AlunoId == alunoId)
                .FirstOrDefault();
        }

        public void CreateAluno(Aluno aluno)
        {
            Create(aluno);
        }

        public void UpdateAluno(Aluno dbAluno, Aluno aluno)
        {
            dbAluno.Map(aluno); // O parametro com this usa o objeto que esta chamando o método
            Update(dbAluno);
        }

        public void DeleteAluno(Aluno aluno)
        {
            Delete(aluno);
        }

        private void SearchByName(ref IQueryable<Aluno> alunos, string nome)
        {
            if (!alunos.Any() || string.IsNullOrWhiteSpace(nome))
                return;

            alunos = alunos.Where(o => o.Nome.ToLower().Contains(nome.Trim().ToLower()));
        }

        private void ApplySort(ref IQueryable<Aluno> alunos, string orderByQueryString)
        {
            if (!alunos.Any())
                return;

            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                alunos = alunos.OrderBy(a => a.Nome);
                return;
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Aluno).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach(var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                alunos = alunos.OrderBy(a => a.Nome);
            }

            alunos = alunos.OrderBy(orderQuery);
        }
    }
}
