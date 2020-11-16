using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AlunoParameters : QueryStringParameters
    {
        public AlunoParameters()
        {
            OrderBy = "nome"; // Campo padrão para sort
        }

        public string Nome { get; set; }
    }
}
