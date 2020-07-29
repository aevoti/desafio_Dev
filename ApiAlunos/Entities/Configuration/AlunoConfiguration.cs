using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Configuration
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
                    },
                    new Aluno
                    {
                        AlunoId = 4,
                        Nome = "Carlos de Nobrega",
                        Email = "carlos.haha@outlook.com.br"
                    },
                    new Aluno
                    {
                        AlunoId = 5,
                        Nome = "Douglas Correia",
                        Email = "douglas.correia@outlook.com.br"
                    },
                    new Aluno
                    {
                        AlunoId = 6,
                        Nome = "Pamela Albur",
                        Email = "pamela.albur@outlook.com.br"
                    },
                    new Aluno 
                    {
                        AlunoId = 7,
                        Nome = "Diogo Almeida",
                        Email = "diogo.almeida@outlook.com.br"
                    },
                    new Aluno
                    {
                        AlunoId = 8,
                        Nome = "Samanta de Almeida Costa",
                        Email = "sac@outlook.com.br"
                    }
                );
        }
    }
}
