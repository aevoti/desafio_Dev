using Alunos.Domain;
using Alunos.Infra.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiAlunos
{
    public class AlunosSeedDataService
    {
        private readonly AppDbContext context;
        private readonly IAlunoRepository alunoRepository;

        public AlunosSeedDataService(AppDbContext context, IAlunoRepository alunoRepository)
        {
            this.context = context;
            this.alunoRepository = alunoRepository;
        }

        public async Task FeedDb()
        {
            if (alunoRepository.GetAlunos().Count() == 0)
            {
                foreach(var aluno in GetAlunos())
                    await alunoRepository.Add(aluno);

                await context.SaveChangesAsync();
            }
        }

        public IList<Aluno> GetAlunos()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(dir + "/Alunos/alunos.json");

            return JsonSerializer.Deserialize<List<AlunoJson>>(json)
                .Select(a => new Aluno(a.Email, a.Nome))
                .ToList();
        }


        private class AlunoJson
        {
            public string Email { get; set; }
            public string Nome { get; set; }
        }
    }
}
