using ApiAlunos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ApiAlunos.Infra.Data;
using Microsoft.Extensions.Configuration;

namespace ApiAlunos.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseNpgsql(DatabaseConnection.ConnectionConfiguration.
                    GetConnectionString("Default")); 
            }
        }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Aluno> Alunos { get; set; }
    }
}
