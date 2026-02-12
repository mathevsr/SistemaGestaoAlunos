using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoAlunos.Application.DTOs.Aluno
{
    public class CreateAlunoDto
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public DateTime DataNascimento { get; set; }

        [Range(0.5, 2.5)]
        public decimal Altura { get; set; }

        [Range(1, 500)]
        public decimal Peso { get; set; }
    }
}
