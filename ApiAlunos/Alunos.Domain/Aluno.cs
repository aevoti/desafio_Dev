using System;

namespace Alunos.Domain
{
    public class Aluno
    {
        public Aluno(string email, string nome)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException();

            Email = email;
            Nome = nome;
        }

        protected Aluno() { }

        public int AlunoId { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }

        public void UpdateNome(string novoNome)
        {
            if (string.IsNullOrEmpty(novoNome))
                throw new ArgumentNullException(nameof(novoNome));

            Nome = novoNome;
        }

        public void UpdateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            Email = email;
        }
    }
}
