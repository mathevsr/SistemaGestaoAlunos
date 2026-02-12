namespace SistemaGestaoAlunos.Application.DTOs.Aluno
{
    public class AlunoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
    }
}
