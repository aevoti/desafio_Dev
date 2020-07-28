using ApiAlunos.Context;
using ApiAlunos.Controllers;
using ApiAlunos.Models;
using ApiAlunos.Repository;
using ApiAlunos.Test;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace ApiAlunos.Teste
{
    public class AlunoUnitTestController
    {
        private AlunoRepository repository;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;";


        static AlunoUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public AlunoUnitTestController()
        {
            var context = new AppDbContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new AlunoRepository(context);
        }

        #region GetAlunos

        [Fact]
        public async void Task_GetAlunos_Return_OkResult()
        {
            
            var controller = new AlunosController(repository);

            
            var data = await controller.GetAlunos();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<Aluno>>>(data);
        }

        [Fact]
        public void Task_GetAlunos_Return_BadRequestResult()
        {
            
            var controller = new AlunosController(repository);

            
            var data = controller.GetAlunos();
            data = null;

            if (data != null)

                Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetAlunos_MatchResult()
        {
            
            var controller = new AlunosController(repository);
            var data = await controller.GetAlunos();
            Assert.IsType<ActionResult<IEnumerable<Aluno>>>(data);

            var okResult = data.Should().BeOfType<ActionResult<IEnumerable<Aluno>>>().Subject;
            var alunos = okResult.Value.Should().BeAssignableTo<IEnumerable<Aluno>>().Subject;

            Assert.Equal("João Silva", alunos.First().Nome);
            Assert.Equal("joao.silva@gmail.com", alunos.First().Email);

            Assert.Equal("Luiza Amorim", alunos.Last().Nome);
            Assert.Equal("luiza.amorim@gmail.com", alunos.Last().Email);
        }

        #endregion
        #region GetAluno

        [Fact]
        public async void Task_GetAluno_Return_OkResult()
        {
            var controller = new AlunosController(repository);
            var alunoId = 3;
            var data = await controller.GetAluno(alunoId);
            Assert.IsType<ActionResult<Aluno>>(data);
        }

        [Fact]
        public async void Task_GetAluno_Return_NotFoundResult()
        {
            var controller = new AlunosController(repository);
            var alunoId = 550;
            var data = await controller.GetAluno(alunoId);
            Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        public async void Task_GetAluno_Return_BadRequestResult()
        {
            var controller = new AlunosController(repository);
            int? alunoId = null;
            var data = await controller.GetAluno(alunoId);
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public async void Task_GetAluno_MatchResult()
        {
            var controller = new AlunosController(repository);
            int alunoId = 1;
            var data = await controller.GetAluno(alunoId);
            Assert.IsType<ActionResult<Aluno>>(data);

            var okResult = data.Should().BeOfType<ActionResult<Aluno>>().Subject;
            var aluno = okResult.Value.Should().BeAssignableTo<Aluno>().Subject;

            Assert.Equal("João Silva", aluno.Nome);
            Assert.Equal("joao.silva@gmail.com", aluno.Email);
        }
        #endregion

        #region GetAlunoByName

        [Fact]
        public async void Task_GetAlunoByName_Return_OkResult()
        {
            var controller = new AlunosController(repository);
            var alunoNome = "João Silva";
            var data = await controller.GetAlunoByName(alunoNome);
            Assert.IsType<ActionResult<Aluno>>(data);
        }

        [Fact]
        public async void Task_GetAlunoByName_Return_NotFoundResult()
        {
            var controller = new AlunosController(repository);
            var alunoId = "Peralta Silva";
            var data = await controller.GetAlunoByName(alunoId);
            Assert.IsType<NotFoundResult>(data.Result);
        }


        [Fact]
        public async void Task_GetAlunoByName_MatchResult()
        {
            var controller = new AlunosController(repository);
            string alunoNome = "João Silva";
            var data = await controller.GetAlunoByName(alunoNome);
            Assert.IsType<ActionResult<Aluno>>(data);

            var okResult = data.Should().BeOfType<ActionResult<Aluno>>().Subject;
            var aluno = okResult.Value.Should().BeAssignableTo<Aluno>().Subject;

            Assert.Equal(alunoNome, aluno.Nome);
            Assert.Equal("joao.silva@gmail.com", aluno.Email);
        }
        #endregion

        #region Add AlunoAluno

        [Fact]
        public async void Task_PostAluno_ValidData_Return_OkResult()
        {
            var controller = new AlunosController(repository);
            var Aluno = new Aluno() { Nome = "Joaquim do Teste", Email = "joaquim.teste@gmail.com" };

            var data = await controller.PostAluno(Aluno);
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public async void Task_PostAluno_InvalidData_Return_BadRequest()
        {

            var controller = new AlunosController(repository);
            Aluno Aluno = new Aluno() { AlunoId = 12, Nome = "Joaquim do Teste", Email = "joaquim.teste@gmail.com" };
         
            var data = await controller.PostAluno(Aluno);
            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public async void Task_PostAluno_ValidData()
        {
            var controller = new AlunosController(repository);
            var aluno = new Aluno() { Nome = "Joaquim do Teste", Email = "joaquim.teste@gmail.com"};
            var data = await controller.PostAluno(aluno);

            data.Should().BeOfType<CreatedAtActionResult>()
                    .Which.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        #endregion
        #region PutAluno

        [Fact]
        public async void Task_PutAluno_Return_NoContent()
        {
            var controller = new AlunosController(repository);
            var alunoId = 3;

            var existingPost = await controller.GetAluno(alunoId);
            var okResult = existingPost.Should().BeOfType<ActionResult<Aluno>>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Aluno>().Subject;

            var aluno = new Aluno();
            aluno.AlunoId = alunoId;
            aluno.Nome = "Pedro Rocha";
            aluno.Email = "pedro123.rocha@gmail.com";


            var updatedData = await controller.PutAluno(3, aluno);

            Assert.IsType<NoContentResult>(updatedData);
        }

        [Fact]
        public async void Task_PutAluno_Return_BadRequest()
        {

            var controller = new AlunosController(repository);
            var alunoId = 2;

            var existingPost = await controller.GetAluno(alunoId);
            var okResult = existingPost.Should().BeOfType<ActionResult<Aluno>>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Aluno>().Subject;

            var aluno = new Aluno();
            aluno.Nome = "Maria Pereira Silva Sauro";
            aluno.Email = "maria.sauro@gmail.com";


            var data = await controller.PutAluno(3, aluno);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_PutAluno_Return_NotFound()
        {
            var controller = new AlunosController(repository);
            var alunoId = 2;

            var existingPost = await controller.GetAluno(alunoId);
            var okResult = existingPost.Should().BeOfType<ActionResult<Aluno>>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Aluno>().Subject;

            var aluno = new Aluno();
            aluno.AlunoId = 5;
            aluno.Nome = "Maria Pereira Silva Sauro";
            aluno.Email = "maria.sauro@gmail.com";

            var data = await controller.PutAluno(aluno.AlunoId,aluno);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        #endregion
        #region DeleteAluno

        [Fact]
        public async void Task_DeleteAluno_Return_OkResult()
        {
            //Arrange
            var controller = new AlunosController(repository);
            var postId = 2;

            //Act
            var data = await controller.DeleteAluno(postId);

            //Assert
            Assert.IsType<ActionResult<Aluno>>(data);
        }

        [Fact]
        public async void Task_DeleteAluno_Return_NotFoundResult()
        {
            //Arrange
            var controller = new AlunosController(repository);
            var postId = 5;

            //Act
            var data = await controller.DeleteAluno(postId);

            //Assert
            Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        public async void Task_DeleteAluno_BadRequestResult()
        {
            //Arrange
            var controller = new AlunosController(repository);
            int? postId = null;

            //Act
            var data = await controller.DeleteAluno(postId);

            //Assert
            Assert.IsType<BadRequestResult>(data.Result);
        }

        #endregion
    }
}