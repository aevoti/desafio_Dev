using System;
using System.Collections.Generic;
using System.Text;
using ApiAlunos.Domain.Models;
using ApiAlunos.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace ApiAlunos.IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(AlunoDbContext db)
        {
            db.Alunos.AddRange(GetSeedingAlunos());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(AlunoDbContext db)
        {
            db.Alunos.RemoveRange(db.Alunos);
            InitializeDbForTests(db);
        }

        public static List<Aluno> GetSeedingAlunos()
        {
            return new List<Aluno>()
            {
                new Aluno(){ Id = 1, Nome = "Corban Best", Email = "corbanbest@example.com" },
                new Aluno(){ Id = 2, Nome = "Priya Hull", Email = "priyahull@example.com" },
                new Aluno(){ Id = 3, Nome = "Harrison Vu", Email = "harrisonvu@example.com"}
            };
        }

        public static WebApplicationFactory<Startup> BuildApplicationFactory(this WebApplicationFactory<Startup> factory)
        {
            return factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(DbContext));
                    services.AddDbContext<AlunoDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDb");
                    });


                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<AlunoDbContext>();
                        var logger = scopedServices
                            .GetRequiredService<ILogger<WebApplicationFactory<Startup>>>();

                        db.Database.EnsureCreated();

                        try
                        {
                            Utilities.InitializeDbForTests(db);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred seeding the " +
                                                "database with test messages. Error: {Message}", ex.Message);
                        }
                    }
                });
            });
        }


        public static WebApplicationFactory<Startup> RebuildDb(this WebApplicationFactory<Startup> factory)
        {
            return factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices
                            .GetRequiredService<AlunoDbContext>();
                        var logger = scopedServices
                            .GetRequiredService<ILogger<IntegrationTest>>();
                        try
                        {
                            Utilities.ReinitializeDbForTests(db);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred seeding " +
                                                "the database with test messages. Error: {Message}",
                                ex.Message);
                        }
                    }
                });
            });
        }


    }
}
