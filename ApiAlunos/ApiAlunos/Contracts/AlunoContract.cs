using ApiAlunos.Models;
using System.Collections.Generic;

namespace ApiAlunos.Contracts
{
    public interface IAlunoContract
    {
        public List<Aluno> GetAlunosByAscendingOrder();
        public Aluno GetAlunoByIdAndName(int? id, string name);
    }
}
