using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAlunos.Domain.Models;
using ApiAlunos.Infrastructure.Context;
using ApiAlunos.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ApiAlunos.UnitTests
{
    public class AlunoRepositoryTests
    {
        private AlunoDbContext CreateDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<AlunoDbContext>()
            .UseInMemoryDatabase(name)
            .Options;
            return new AlunoDbContext(options);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async Task GetById_existing_Alunos(int id)
        {
            // Arrange

            using (var context = CreateDbContext("GetById_existing_Alunos"))
            {
                context.Set<Aluno>().Add(new Aluno { Id = id });
                await context.SaveChangesAsync();
            }
            Aluno aluno = null;

            // Act
            using (var context = CreateDbContext("GetById_existing_Alunos"))
            {
                var repository = new AlunoRepository(context);
                aluno = await repository.GetById(id);
            }
            // Assert
            aluno.Should().NotBeNull();
            aluno.Id.Should().Be(id);
        }

        [Theory]
        [InlineData(500)]
        [InlineData(5000)]
        [InlineData(50000)]
        [InlineData(1000)]
        [InlineData(200)]
        public async Task GetById_inexistent_Alunos(int id)
        {
            // Arrange
            using (var context = CreateDbContext("GetById_inexistent_Alunos"))
            {
                context.Set<Aluno>().Add(new Aluno());
                await context.SaveChangesAsync();
            }
            Aluno Aluno = null;

            // Act
            using (var context = CreateDbContext("GetById_inexistent_Alunos"))
            {
                var repository = new AlunoRepository(context);
                Aluno = await repository.GetById(id);
            }
            // Assert
            Aluno.Should().BeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public async Task GetAll_Alunos(int count)
        {
            // Arrange
            using (var context = CreateDbContext($"GetAll_Alunos_{count}"))
            {
                for (var i = 0; i < count; i++)
                {
                    context.Set<Aluno>().Add(new Aluno());
                }
                await context.SaveChangesAsync();
            }
            List<Aluno> alunos = null;
            // Act
            using (var context = CreateDbContext($"GetAll_Alunos_{count}"))
            {
                var repository = new AlunoRepository(context);
                alunos = await repository.GetAll().ToListAsync();
            }
            // Assert
            alunos.Should().NotBeNull();
            alunos.Count().Should().Be(count);
        }

        [Fact]
        public async Task Create_Aluno()
        {
            // Arrange
            int result;


            // Act
            var Aluno = new Aluno()
            {
                Nome = "Yan Pitangui",
                Email = "yanpitangui@exemplo.com"
            };

            using (var context = CreateDbContext("Create_Aluno"))
            {
                var repository = new AlunoRepository(context);
                repository.Create(Aluno);
                result = await repository.SaveChangesAsync();
            }


            // Assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(1);
            // Simular acesso de outro dbcontext para verificar se ação foi executada com sucesso
            using (var context = CreateDbContext("Create_Aluno"))
            {
                (await context.Alunos.CountAsync()).Should().Be(1);
                var verificacao = await context.Alunos.FirstAsync();

                verificacao.Id.Should().Be(Aluno.Id);
                verificacao.Nome.Should().Be(Aluno.Nome);
                verificacao.Email.Should().Be(Aluno.Email);
            }
        }

        [Fact]
        public async Task Update_Aluno()
        {
            // Arrange
            int result;
            int? id;
            using (var context = CreateDbContext("Update_Aluno"))
            {
                var createdAluno = new Aluno()
                {
                    Nome = "Yan Pitangui",
                    Email = "yanpitangui@exemplo.com"
                };

                context.Set<Aluno>().Add(createdAluno);
                context.Set<Aluno>().Add(new Aluno() { Nome = "Outro Aluno", Email = "verificar@diferenca.com.br" });
                await context.SaveChangesAsync();
                id = createdAluno.Id; // Pegar id gerado para verificar depois
            }

            // Act
            Aluno updateAluno;
            using (var context = CreateDbContext("Update_Aluno"))
            {
                updateAluno = await context.Set<Aluno>().FirstOrDefaultAsync(x => x.Id == id);
                updateAluno.Nome = "Novo nome";
                updateAluno.Email = "Novo email";
                var repository = new AlunoRepository(context);
                repository.Update(updateAluno);
                result = await repository.SaveChangesAsync();
            }


            // Assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(1);

            // Simular acesso de outro dbcontext para verificar se ação foi executada com sucesso
            using (var context = CreateDbContext("Update_Aluno"))
            {
                var verificacao = await context.Alunos.FirstAsync(x => x.Id == updateAluno.Id);
                verificacao.Id.Should().Be(updateAluno.Id);
                verificacao.Nome.Should().Be(updateAluno.Nome);
                verificacao.Email.Should().Be(updateAluno.Email);
            }
        }

        [Fact]
        public async Task Delete_Aluno()
        {
            // Arrange
            int result;
            int? id;
            using (var context = CreateDbContext("Delete_Aluno"))
            {
                var createdAluno = new Aluno()
                {
                    Nome = "Yan Pitangui",
                    Email = "yanpitangui@exemplo.com"
                };
                context.Set<Aluno>().Add(createdAluno);
                context.Set<Aluno>().Add(new Aluno() { Nome = "Outro Aluno", Email = "outroaluno@gmail.com"});
                await context.SaveChangesAsync();
                id = createdAluno.Id; // Pegar id gerado para verificar depois
            }

            // Act
            using (var context = CreateDbContext("Delete_Aluno"))
            {
                var repository = new AlunoRepository(context);
                await repository.Delete(id.Value);
                result = await repository.SaveChangesAsync();
            }


            // Assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(1);
            // Simular acesso de outro dbcontext para verificar se ação foi executada com sucesso
            using (var context = CreateDbContext("Delete_Aluno"))
            {
                (await context.Set<Aluno>().FirstOrDefaultAsync(x => x.Id == id)).Should().BeNull();
                (await context.Set<Aluno>().ToListAsync()).Should().NotBeEmpty();
            }
        }
    }
}
