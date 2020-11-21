using NUnit.Framework;
using ApiAlunos.Infra.Data.Context;
using ApiAlunos.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using ApiAlunos.Infra.Crosscutting;
using ApiAlunos.Domain.Interfaces.Repository;
using System.Linq;

namespace ApiAlunos.Test
{
    public class TestBase
    {
        public AppDbContext DbContext { get; set; }
        public ServiceProvider ServiceProvider { get; set; }

        public TestBase()
        {
            IServiceCollection services = new ServiceCollection();
            IoC.RegisterServices(services);

            ServiceProvider = services.BuildServiceProvider();
            
            DbContext = ServiceProvider.GetService<AppDbContext>();
            
        }

        public virtual void Setup() {
            DbContext.Alunos.RemoveRange(DbContext.Alunos);
            DbContext.SaveChanges();
        }
    }
}