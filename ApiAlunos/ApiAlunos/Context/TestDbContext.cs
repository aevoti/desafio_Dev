using ApiAlunos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
    }
}
