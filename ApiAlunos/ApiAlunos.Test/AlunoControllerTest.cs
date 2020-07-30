using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using ApiAlunos.Services;
using ApiAlunos.Repositorio;
using ApiAlunos.Context;
using Microsoft.EntityFrameworkCore;
using ApiAlunos.Models;
using ApiAlunos.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ApiAlunos.Test
{
    public class AlunoControllerTest
    {
        private AlunoAppService _service;
        public static DbContextOptions<AlunoDbContext> dbContextOptions { get; }

        static AlunoControllerTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<AlunoDbContext>()
                            .UseInMemoryDatabase("SQL")
                            .Options;
        }

        public AlunoControllerTest()
        {
            var context = new AlunoDbContext(dbContextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Alunos.AddRange(
                new Aluno() { Nome = "Lucas Panetto", Email = "lucaspanetto@ucl.br" },
                new Aluno() { Nome = "Leticia Ribeiro", Email = "ribeiro.leticia@uol.com" }
            );

            context.SaveChanges();

            AlunoRepository repository = new AlunoRepository(context);
            _service = new AlunoAppService(repository);
        }

        [Fact]
        public async void ObterAlunosSucesso()
        {
            var result = await _service.ObterTodosAlunos();

            Assert.IsType<List<Aluno>>(result);
            Assert.Equal(result.Count, 2);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void ObterAlunoPorIdSucesso(int valor)
        {
            var result = await _service.ObterAlunoPorId(valor);

            Assert.IsType<Aluno>(result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public async void ObterAlunoPorIdErro(int valor)
        {
            var result = await _service.ObterAlunoPorId(valor);

            Assert.Equal(result, null);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void AtualizarAlunoSucesso(int valor)
        {
            Aluno aluno = new Aluno()
            {
                AlunoId = 1,
                Nome = "César Miranda",
                Email = "cesar.miranda@outlook.com"
            };

            var result = await _service.AtualizarAluno(aluno);

            Assert.Equal(true, result);
        }

        //[Theory]
        //[InlineData(3)]
        //[InlineData(4)]
        //public async void AtualizarAlunoErro(int valor)
        //{
        //    Aluno aluno = new Aluno()
        //    {
        //        AlunoId = valor,
        //        Nome = "César Miranda",
        //        Email = "cesar.miranda@outlook.com"
        //    };

        //    var result = await _alunosController.AtualizarAluno(aluno);

        //    Assert.Equal(result.Value, aluno);
        //}

        [Fact]
        public void InserirAlunoSucesso()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "César Miranda",
                Email = "cesar.miranda@outlook.com"
            };

            var result = _service.CriarAluno(aluno).Result;

            Assert.Equal(result, aluno);
        }

        [Fact]
        public void InserirAlunoErro()
        {
            try
            {
                Aluno aluno = new Aluno();
                aluno.Nome = "";
                aluno.Email = "cesar.miranda@outlook.com";

                var result = _service.CriarAluno(aluno).Result;
            }
            catch (System.Exception ex)
            {
                Assert.Equal(ex.InnerException.Message, "Todos os campos são obrigatórios!");
            }

        }
    }
}
