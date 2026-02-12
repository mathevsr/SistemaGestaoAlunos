using Microsoft.EntityFrameworkCore;
using SistemaGestaoAlunos.Domain.Entities;
using SistemaGestaoAlunos.Infrastructure.Data.Mappings;

namespace SistemaGestaoAlunos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(entity =>
            {
                // Altura: ex 1.75, 1.80
                entity.Property(a => a.Altura)
                      .HasPrecision(5, 2);

                // Peso: ex 80.50, 102.30
                entity.Property(a => a.Peso)
                      .HasPrecision(6, 2);
            });


        }
    }
}
