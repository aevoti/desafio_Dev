using ApiAlunos.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAlunos.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
    }
}
