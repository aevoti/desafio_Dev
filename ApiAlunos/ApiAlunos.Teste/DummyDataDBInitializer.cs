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

        public void Seed(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Alunos.AddRange(
                new Aluno() {Nome = "João Silva", Email = "joao.silva@gmail.com" },            //AlunoId = 1
                new Aluno() {Nome = "Maria Silva", Email = "maria.silva@gmail.com" },         // AlunoId = 2
                new Aluno() {Nome = "Pedro Rocha", Email = "pedro.rocha@gmail.com" },         // AlunoId = 3
                new Aluno() {Nome = "Luiza Amorim", Email = "luiza.amorim@gmail.com" }        // AlunoId = 4
            );

           
            context.SaveChanges();
        }
    }
}
