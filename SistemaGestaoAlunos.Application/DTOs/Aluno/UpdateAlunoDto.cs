namespace SistemaGestaoAlunos.Application.DTOs.Aluno
{
    // DTO usado para atualizar um aluno
    public class UpdateAlunoDto
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
    }
}
