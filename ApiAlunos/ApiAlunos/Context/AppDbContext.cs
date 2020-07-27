using ApiAlunos.Context.Mappings;
using ApiAlunos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAlunos.Context
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
