using NUnit.Framework;
using ApiAlunos.Domain.Interfaces.Service;
using ApiAlunos.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ApiAlunos.Test
{
    public class AlunoServiceTest : TestBase
    {
        private IAlunoService _alunoService;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _alunoService = ServiceProvider.GetService<IAlunoService>();
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
                _alunoService.Add(aluno);
            }

            alunos = _alunoService.GetAll().ToArray();

            Assert.AreEqual(2, alunos.Length, "Não carregou 2 alunos");
        }

        [Test]
        public void Get()
        {
            Aluno aluno = new Aluno { Nome = "Teste2", Email = "teste2@teste.com" };
            aluno = _alunoService.Add(aluno);

            var alunoDb = _alunoService.Get(aluno.AlunoId);
            Assert.AreEqual(aluno.AlunoId, alunoDb.AlunoId, "Aluno não foi encontrado");
        }

        [Test]
        public void Update()
        {
            Aluno aluno = new Aluno { Nome = "Teste2", Email = "teste2@teste.com" };
            aluno = _alunoService.Add(aluno);
            aluno.Nome = "Teste3";
            _alunoService.Update(aluno);

            var alunoDb = _alunoService.Get(aluno.AlunoId);
            Assert.AreEqual(aluno.Nome, alunoDb.Nome, "Aluno não foi atualizado");
        }

        [Test]
        public void Remove()
        {
            Aluno aluno = new Aluno { Nome = "Teste2", Email = "teste2@teste.com" };
            aluno = _alunoService.Add(aluno);
            _alunoService.Remove(aluno);
            DbContext.SaveChanges();

            var alunoDb = _alunoService.Get(aluno.AlunoId);
            Assert.AreEqual(null, alunoDb, "Aluno não foi removido");
        }
    }
}