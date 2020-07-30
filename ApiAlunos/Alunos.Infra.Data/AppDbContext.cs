using Alunos.Domain;
using Alunos.Infra.Data.Alunos;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
        }
    }
}
