using ApiAlunos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Configuration
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder
                .HasData(
                    new Aluno
                    {   
                        AlunoId = 1,
                        Nome = "Douglas Silva",
                        Email = "douglass.sousa@outlook.com.br"
                    },
                    new Aluno
                    {
                        AlunoId = 2,
                        Nome = "João Neto",
                        Email = "joao.neto@outlook.com.br"
                    },
                    new Aluno
                    {
                        AlunoId = 3,
                        Nome = "Carlos Almeida",
                        Email = "carlos.almeida@outlook.com.br"
                    }
                );
        }
    }
}
