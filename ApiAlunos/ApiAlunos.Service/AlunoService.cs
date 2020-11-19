using ApiAlunos.Domain.Interfaces.Service;
using ApiAlunos.Domain.Interfaces.Repository;
using ApiAlunos.Domain.Models;

namespace ApiAlunos.Service
{
    public class AlunoService : BaseService<Aluno>, IAlunoService
    {
        public AlunoService(IAlunoRepository alunoRepository) : base(alunoRepository) 
        {
        }
    }
}