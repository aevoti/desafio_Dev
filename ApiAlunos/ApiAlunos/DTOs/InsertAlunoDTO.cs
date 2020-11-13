using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.DTOs
{
    public class InsertAlunoDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        public string  Email { get; set; }
    }
}
