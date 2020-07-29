using ApiAlunos.Controllers;
using Contracts;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace ApiAlunos.Test
{
    public class AlunoControllerTests
    {
        private readonly AlunosController _controller;

        public AlunoControllerTests()
        {
            _controller = new AlunosController(GetAlunoInMemoryRepository());
        }

        #region POST
        #endregion POST

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
