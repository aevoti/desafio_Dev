using Alunos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alunos.Infra.Data.Alunos
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(a => a.AlunoId);

            builder.Property(a => a.Email)
                .HasMaxLength(256)
                .HasColumnName("Email");

            builder.Property(a => a.Nome)
                .HasMaxLength(100)
                .HasColumnName("Nome");
        }
    }
}
