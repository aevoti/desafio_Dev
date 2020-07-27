using ApiAlunos.Context;
using ApiAlunos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiAlunos
{
    public class SeedDataService
    {
        private readonly AppDbContext context;

        public SeedDataService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task FeedDb()
        {
            if (context.Alunos.Count() == 0)
            {
                var alunos = await GetAlunos();

                await context.Alunos.AddRangeAsync(alunos);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IList<Aluno>> GetAlunos()
        {
            var json = await File.ReadAllTextAsync("alunos.json");
            var alunos = JsonSerializer.Deserialize<List<Aluno>>(json);
            return alunos;
        }
    }
}
