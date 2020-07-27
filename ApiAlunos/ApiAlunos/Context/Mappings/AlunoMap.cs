using ApiAlunos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlunos.Context.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(a => a.AlunoId);

            builder.Property(a => a.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(a => a.Nome)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
