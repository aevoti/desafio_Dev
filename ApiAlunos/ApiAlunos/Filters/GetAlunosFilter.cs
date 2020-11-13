using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Filters
{
    /// <summary>
    /// Filtro para o GetAllAlunos
    /// </summary>
    public class GetAlunosFilter
    {
        /// <summary>
        /// Nome do aluno a ser filtrado
        /// </summary>
        public string Nome { get; set; }
    }
}
