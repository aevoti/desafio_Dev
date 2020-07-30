using System;

namespace Alunos.Domain
{
    public class Aluno
    {
        public Aluno(string email, string nome)
        {
            Email = email;
            Nome = nome;
        }

        protected Aluno() { }

        public int AlunoId { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }

        public void UpdateNome(string novoNome)
        {
            if (novoNome is null)
                throw new ArgumentNullException(nameof(novoNome));

            Nome = novoNome;
        }

        public void UpdateEmail(string email)
        {
            if (email is null)
                throw new ArgumentNullException(nameof(email));

            Email = email;
        }
    }
}
