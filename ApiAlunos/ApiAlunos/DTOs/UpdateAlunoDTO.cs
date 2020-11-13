using System.ComponentModel.DataAnnotations;

namespace ApiAlunos.DTOs
{
    public class UpdateAlunoDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório.", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.",  AllowEmptyStrings = false)]
        public string  Email { get; set; }
    }
}
