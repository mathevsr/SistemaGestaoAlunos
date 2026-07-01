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

        public DbSet<Usuario> Usuarios { get; set; }

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

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Nome)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(u => u.Email)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.HasIndex(u => u.Email)
                      .IsUnique();

                entity.Property(u => u.SenhaHash)
                      .IsRequired();

                entity.Property(u => u.Role)
                      .HasMaxLength(30)
                      .IsRequired();
            });


        }



    }


}
