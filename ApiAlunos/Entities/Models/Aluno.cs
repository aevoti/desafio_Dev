using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        [EmailAddress]
        public string  Email { get; set; }

    }
}
