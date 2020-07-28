using Contracts;
using Entities.Context;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
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

        [Fact]
        public void Get_SeededData()
        {
            PagedList<Aluno> alunos = _repo.Aluno.GetAlunos(new AlunoParameters { });

            Assert.Equal(6, alunos.TotalCount);
            Assert.Equal(1, alunos.TotalPages);
        }

        [Fact]
        public void Get_SeededDataWithSearchParam()
        {
            PagedList<Aluno> alunos = _repo.Aluno.GetAlunos(new AlunoParameters { Nome = "Douglas" });

            Assert.Equal(2, alunos.TotalCount);
            Assert.Equal(1, alunos.TotalPages);
            Assert.All(alunos, aluno => Assert.Contains("Douglas", aluno.Nome));
        }

        [Fact]
        public void Add_WithAllProperties()
        {
            Aluno aluno = new Aluno()
            {
                AlunoId = 7,
                Nome = "Cleber Andrade",
                Email = "clebin@hotmail.com"
            };

            _repo.Aluno.Create(aluno);

            _repo.Save();

            Aluno savedAluno = _repo.Aluno.GetAlunoById(aluno.AlunoId);

            Assert.Equal(7, savedAluno.AlunoId);
            Assert.Equal("Cleber Andrade", savedAluno.Nome);
            Assert.Equal("clebin@hotmail.com", savedAluno.Email);
        }

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
