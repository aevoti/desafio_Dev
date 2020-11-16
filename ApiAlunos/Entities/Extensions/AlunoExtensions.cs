using Entities.Models;

namespace Entities.Extensions
{
    public static class AlunoExtensions
    {
        public static void Map(this Aluno dbAluno, Aluno aluno)
        {
            dbAluno.Nome = aluno.Nome;
            dbAluno.Email = aluno.Email;
        }
    }
}
