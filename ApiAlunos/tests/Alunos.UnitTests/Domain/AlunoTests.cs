using Alunos.Domain;
using FluentAssertions;
using System;
using Xunit;

namespace Alunos.UnitTests
{
    public class AlunoTests
    {
        [Fact]
        public void Ctor_ShouldThrowExceptionOnNullOrEmptyEmail()
        {
            string email = null;
            string nome = "Some Cool Name";

            Assert.Throws<ArgumentNullException>(() =>
            {
                new Aluno(email, nome);
            });
        }

        [Fact]
        public void Ctor_ShouldThrowExceptionOnNullOrEmptyNome()
        {
            string email = "abc@example.com";
            string nome = "";

            Assert.Throws<ArgumentNullException>(() =>
            {
                new Aluno(email, nome);
            });
        }

        [Fact]
        public void Ctor_ShouldReturnAlunoOnValidData()
        {
            string email = "abc@example.com";
            string nome = "Some Cool Nome";

            var aluno = new Aluno(email, nome);

            aluno.Should().BeOfType<Aluno>();
            aluno.Email.Should().Be(email);
            aluno.Nome.Should().Be(nome);
        }

        [Fact]
        public void UpdateNome_ShouldThrowExceptionOnNullOrEmptyNome()
        {
            string email = "abc@example.com";
            string nome = "Some Cool Nome";
            var aluno = new Aluno(email, nome);

            var novoNome = "";

            Assert.Throws<ArgumentNullException>(() =>
            {
                aluno.UpdateNome(novoNome);
            });
        }

        [Fact]
        public void UpdateNome_ShouldAlterNomeOnValidNome()
        {
            string email = "abc@example.com";
            string nome = "Some Cool Nome";
            var aluno = new Aluno(email, nome);

            var novoNome = "Really Cool Nome";

            aluno.UpdateNome(novoNome);

            aluno.Nome.Should().Be(novoNome);
        }

        [Fact]
        public void UpdateEmail_ShouldThrowExceptionOnNullOrEmptyEmail()
        {
            string email = "abc@example.com";
            string nome = "Some Cool Nome";
            var aluno = new Aluno(email, nome);

            var novoEmail = "";

            Assert.Throws<ArgumentNullException>(() =>
            {
                aluno.UpdateEmail(novoEmail);
            });
        }

        [Fact]
        public void UpdateEmail_ShouldAlterEmailOnValidEmail()
        {
            string email = "abc@example.com";
            string nome = "Some Cool Nome";
            var aluno = new Aluno(email, nome);

            var novoEmail = "abc2@example.com";

            aluno.UpdateEmail(novoEmail);

            aluno.Email.Should().Be(novoEmail);
        }
    }
}
