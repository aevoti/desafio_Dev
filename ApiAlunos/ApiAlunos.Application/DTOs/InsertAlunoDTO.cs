using System.ComponentModel.DataAnnotations;

namespace ApiAlunos.Application.DTOs
{
    public class InsertAlunoDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }
    }
}