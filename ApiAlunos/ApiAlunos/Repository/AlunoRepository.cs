using ApiAlunos.Context;
using ApiAlunos.Interfaces;
using ApiAlunos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Repository
{
    public class AlunoRepository :Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AppDbContext context) : base(context) { }
    }
}
