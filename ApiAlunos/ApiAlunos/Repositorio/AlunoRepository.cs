using ApiAlunos.Context;
using ApiAlunos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Repositorio
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AlunoDbContext dbContext) : base(dbContext) { }
    }
}
