using ApiAlunos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAlunos.Infrastructure.Context
{
    public class AlunoDbContext : DbContext
    {
        public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}