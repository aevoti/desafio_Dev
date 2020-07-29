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
        private AlunosController _alunosController;
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

            AlunoRepository repository = new AlunoRepository(context);
            AlunoAppService service = new AlunoAppService(repository);
            _alunosController = new AlunosController(service);
        }

        [Fact]
        public async void ObterAlunosSucesso()
        {
            var result = await _alunosController.ObterAlunos();

            Assert.IsType<ActionResult<IEnumerable<Aluno>>>(result);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void ObterAlunoPorIdSucesso(int valor)
        {
            var result = await _alunosController.ObterAlunoPorId(valor);

            Assert.IsType<ActionResult<Aluno>>(result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public async void ObterAlunoPorIdErro(int valor)
        {
            var result = await _alunosController.ObterAlunoPorId(valor);

            Assert.Equal(result.Value, null);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void AtualizarAlunoSucesso(int valor)
        {
            Aluno aluno = new Aluno()
            {
                AlunoId = valor,
                Nome = "César Miranda",
                Email = "cesar.miranda@outlook.com"
            };

            var result = await _alunosController.AtualizarAluno(aluno);

            Assert.Equal(result, aluno);
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

            var result = _alunosController.InserirAluno(aluno).Result.Value;

            Assert.Equal(result, aluno);
        }
    }
}
