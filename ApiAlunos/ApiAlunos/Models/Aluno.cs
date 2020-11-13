using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAlunos.Models
{
    public class Aluno : BaseModel
    {
        /// <summary>
        /// Id do aluno
        /// </summary>
        [Key]
        [Column("AlunoId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int? Id { get; set; }


        /// <summary>
        /// Nome do aluno
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Email do aluno
        /// </summary>
        ///
        [Required]
        public string  Email { get; set; }

    }
}
