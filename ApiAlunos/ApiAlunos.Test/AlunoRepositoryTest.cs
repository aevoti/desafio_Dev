using NUnit.Framework;
using ApiAlunos.Domain.Interfaces.Repository;
using ApiAlunos.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ApiAlunos.Test
{
    public class AlunoRepositoryTest : TestBase
    {
        private IAlunoRepository _alunoRepository;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _alunoRepository = ServiceProvider.GetService<IAlunoRepository>();
        }

        [Test]
        public void GetAll()
        {
            Aluno[] alunos = new [] {
                new Aluno { Nome = "Teste1", Email = "teste2@teste.com" },
                new Aluno { Nome = "Teste2", Email = "teste2@teste.com" }
            };

            foreach (var aluno in alunos)
            {
                _alunoRepository.Add(aluno);
            }

            alunos = _alunoRepository.GetAll().ToArray();

            Assert.AreEqual(2, alunos.Length, "Não carregou 2 alunos");
        }

        [Test]
        public void Get()
        {
            Aluno aluno = new Aluno { Nome = "Teste2", Email = "teste2@teste.com" };
            aluno = _alunoRepository.Add(aluno);

            var alunoDb = _alunoRepository.Get(aluno.AlunoId);
            Assert.AreEqual(aluno.AlunoId, alunoDb.AlunoId, "Aluno não foi encontrado");
        }

        [Test]
        public void Update()
        {
            Aluno aluno = new Aluno { Nome = "Teste2", Email = "teste2@teste.com" };
            aluno = _alunoRepository.Add(aluno);
            aluno.Nome = "Teste3";
            _alunoRepository.Update(aluno);

            var alunoDb = _alunoRepository.Get(aluno.AlunoId);
            Assert.AreEqual(aluno.Nome, alunoDb.Nome, "Aluno não foi atualizado");
        }

        [Test]
        public void Remove()
        {
            Aluno aluno = new Aluno { Nome = "Teste2", Email = "teste2@teste.com" };
            aluno = _alunoRepository.Add(aluno);
            _alunoRepository.Remove(aluno);
            DbContext.SaveChanges();

            var alunoDb = _alunoRepository.Get(aluno.AlunoId);
            Assert.AreEqual(null, alunoDb, "Aluno não foi removido");
        }
    }
}