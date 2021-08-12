using ApiAlunos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAlunos.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
    }
}
