using ApiAlunos.Context;
using ApiAlunos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAlunos.Test
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(TestDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Alunos.AddRange(
                new Aluno() { AlunoId = 1, Nome = "João Silva", Email = "joao.silva@gmail.com" },
                new Aluno() { AlunoId = 2, Nome = "Maria Silva", Email = "maria.silva@gmail.com" },
                new Aluno() { AlunoId = 3, Nome = "Pedro Rocha", Email = "pedro.rocha@gmail.com" },
                new Aluno() { AlunoId = 4, Nome = "Luiza Amorim", Email = "luiza.amorim@gmail.com" }
            );

           
            context.SaveChanges();
        }
    }
}
