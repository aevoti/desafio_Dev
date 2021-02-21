using DominioAlunos;
using Microsoft.EntityFrameworkCore;

namespace RepositorioAlunos
{
    public class AlunosDbContext : DbContext
    {
        public AlunosDbContext(DbContextOptions<AlunosDbContext> options) : base(options){ }
        public DbSet<Aluno> Alunos { get; set; }
    }
}
