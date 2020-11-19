using ApiAlunos.Domain.Interfaces.Service;
using ApiAlunos.Domain.Interfaces.Repository;
using ApiAlunos.Domain.Models;

namespace ApiAlunos.Service
{
    public class AlunoService : BaseService<Aluno>, IAlunoService
    {
        private IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository) : base(alunoRepository) 
        {
            _alunoRepository = alunoRepository;
        }

        public bool AlunoExists(int id)
        {
            return _alunoRepository.AlunoExists(id);
        }
    }
}