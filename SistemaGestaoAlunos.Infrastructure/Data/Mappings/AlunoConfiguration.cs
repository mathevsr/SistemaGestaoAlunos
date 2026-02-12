using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoAlunos.Domain.Entities;

namespace SistemaGestaoAlunos.Infrastructure.Data.Mappings
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(a => a.DataNascimento)
                   .IsRequired();

            builder.Property(a => a.Altura)
                   .IsRequired();

            builder.Property(a => a.Peso)
                   .IsRequired();
        }
    }
}
