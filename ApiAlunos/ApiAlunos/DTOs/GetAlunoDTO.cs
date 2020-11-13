using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.DTOs
{
    public class GetAlunoDTO
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string  Email { get; set; }
    }
}
