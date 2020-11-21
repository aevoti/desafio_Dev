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
                var connectionString = DatabaseConnection.ConnectionConfiguration.GetConnectionString("POSTGRESQLCONNSTR_Default ") ?? DatabaseConnection.ConnectionConfiguration.GetConnectionString("Default");
                dbContextOptionsBuilder.UseNpgsql(connectionString); 
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
