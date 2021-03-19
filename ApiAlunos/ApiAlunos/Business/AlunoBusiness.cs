using ApiAlunos.Context;
using ApiAlunos.Contracts;
using ApiAlunos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Business
{
    public class AlunoBusiness : IAlunoContract
    {
        private readonly AppDbContext _context;

        public AlunoBusiness(AppDbContext context)
        {
            _context = context;
        }

        public Aluno GetAlunoByIdAndName(int? id, string nome)
        {
            Aluno aluno = new Aluno();
            IQueryable<Aluno> query = _context.Alunos;

            if (id != null) 
                query = query.Where(x => x.AlunoId == id);

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(x => x.Nome.Contains(nome));

            aluno = query.FirstOrDefault();

            return aluno;
        }

        public List<Aluno> GetAlunosByAscendingOrder()
        {
            return _context.Alunos.OrderBy(x => x.Nome).ToList();
        }
    }
}
