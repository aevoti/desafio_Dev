using ApiAlunos.Controllers;
using Contracts;
using Entities.Context;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository;
using System;
using System.Linq;
using Xunit;

namespace ApiAlunos.Test
{
    public class AlunoRepositoryTests
    {
        private readonly IRepositoryWrapper _repo;

        public AlunoRepositoryTests()
        {
            _repo = GetAlunoInMemoryRepository();
        }

        #region GetAll
        [Fact]
        public void GetAll_SeededData()
        {
            PagedList<Aluno> alunos = _repo.Aluno.GetAlunos(new AlunoParameters { });

            Assert.Equal(8, alunos.TotalCount);
            Assert.Equal(1, alunos.TotalPages);
        }

        [Fact]
        public void GetAll_SeededDataWithSearchParam()
        {
            PagedList<Aluno> alunos = _repo.Aluno.GetAlunos(new AlunoParameters { Nome = "Douglas" });

            Assert.Equal(2, alunos.TotalCount);
            Assert.Equal(1, alunos.TotalPages);
            Assert.All(alunos, aluno => Assert.Contains("Douglas", aluno.Nome));
        }

        [Fact]
        public void GetAll_SeededDataWithPageParams()
        {
            PagedList<Aluno> alunos = _repo.Aluno.GetAlunos(new AlunoParameters { PageNumber = 1, PageSize = 4 });

            Assert.Equal(8, alunos.TotalCount);
            Assert.Equal(2, alunos.TotalPages);
            Assert.Equal(4, alunos.Count);
        }

        [Fact]
        public void GetAll_SeededDataWithAscOrderParam()
        {
            PagedList<Aluno> ordered_alunos_api = _repo.Aluno.GetAlunos(new AlunoParameters { OrderBy = "Nome" });
            PagedList<Aluno> alunos = _repo.Aluno.GetAlunos(new AlunoParameters { });

            var ordered_alunos = alunos.OrderBy(a => a.Nome).ToList();

            Assert.Equal(8, alunos.Count);
            Assert.True(ordered_alunos.Select(a => a.Nome).SequenceEqual(ordered_alunos_api.Select(a => a.Nome)));
        }

        [Fact]
        public void GetAll_SeededDataWithDescOrderParam()
       {
            PagedList<Aluno> ordered_alunos_api = _repo.Aluno.GetAlunos(new AlunoParameters { OrderBy = "Nome desc" });
            PagedList<Aluno> alunos = _repo.Aluno.GetAlunos(new AlunoParameters { });

            var ordered_alunos = alunos.OrderByDescending(a => a.Nome).ToList();

            Assert.Equal(8, alunos.Count);
            Assert.True(ordered_alunos.Select(a => a.Nome).SequenceEqual(ordered_alunos_api.Select(a => a.Nome)));
        }

        [Fact]
        public void GetAll_SeededDataWithSearchPageAndOrderParams()
        {
            PagedList<Aluno> ordered_alunos_api = _repo.Aluno.GetAlunos(new AlunoParameters { Nome = "Almeida", PageNumber = 1, PageSize = 3, OrderBy = "Nome" });
            PagedList<Aluno> alunos = _repo.Aluno.GetAlunos(new AlunoParameters { Nome = "Almeida", PageNumber = 1, PageSize = 3 });

            var ordered_alunos = alunos.OrderBy(a => a.Nome).ToList();

            Assert.Equal(3, alunos.Count);
            Assert.Equal(3, alunos.PageSize);
            Assert.Equal(1, alunos.TotalPages);
            Assert.Equal(3, alunos.TotalCount);
            Assert.All(alunos, aluno => Assert.Contains("Almeida", aluno.Nome));
            Assert.True(ordered_alunos.Select(a => a.Nome).SequenceEqual(ordered_alunos_api.Select(a => a.Nome)));
        }
        #endregion GetAll

        #region Get
        [Fact]
        public void Get_SeedDataById()
        {
            Aluno aluno = _repo.Aluno.GetAlunoById(1);

            Assert.Equal(1, aluno.AlunoId);
            Assert.Equal("Douglas Silva", aluno.Nome);
            Assert.Equal("douglass.sousa@outlook.com.br", aluno.Email);
        }

        [Fact]
        public void Get_SeedDataByWrongId()
        {
            Aluno aluno = _repo.Aluno.GetAlunoById(9);

            Assert.True(aluno == null);
        }
        #endregion Get

        #region Add
        [Fact]
        public void Add_WithAllProperties()
        {
            Aluno aluno = new Aluno()
            {
                AlunoId = 9,
                Nome = "Cleber Andrade",
                Email = "clebin@hotmail.com"
            };

            _repo.Aluno.CreateAluno(aluno);

            _repo.Save();

            Aluno savedAluno = _repo.Aluno.GetAlunoById(aluno.AlunoId);

            Assert.Equal(9, savedAluno.AlunoId);
            Assert.Equal("Cleber Andrade", savedAluno.Nome);
            Assert.Equal("clebin@hotmail.com", savedAluno.Email);
        }

        [Fact]
        public void Add_WithoutMail()
        {
            Aluno aluno = new Aluno()
            {
                AlunoId = 10,
                Nome = "Camila Pitanga"
            };

            _repo.Aluno.CreateAluno(aluno);

            _repo.Save();

            Aluno savedAluno = _repo.Aluno.GetAlunoById(10);

            Assert.Equal(10, aluno.AlunoId);
            Assert.Equal("Camila Pitanga", aluno.Nome);
            Assert.Null(aluno.Email);
        }

        [Fact]
        public void Add_WithInvalidMail()
        {
            Aluno aluno = new Aluno()
            {
                AlunoId = 11,
                Nome = "José Franca",
                Email = "josé.franca.com"
            };

            _repo.Aluno.CreateAluno(aluno);
        }
        #endregion Add

        private IRepositoryWrapper GetAlunoInMemoryRepository()
        {
            DbContextOptions<RepositoryContext> options;
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            builder.UseInMemoryDatabase(databaseName: "ConsultasDBTest");
            options = builder.Options;

            RepositoryContext repositoryContext = new RepositoryContext(options);

            repositoryContext.Database.EnsureDeleted();
            repositoryContext.Database.EnsureCreated();            

            return new RepositoryWrapper(repositoryContext);
        }
    }
}
