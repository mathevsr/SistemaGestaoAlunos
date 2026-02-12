using SistemaGestaoAlunos.Application.DTOs.Aluno;

namespace SistemaGestaoAlunos.Application.Services.Alunos
{
    public interface IAlunoService
    {
        Task<AlunoResponseDto> CriarAsync(CreateAlunoDto dto);
        Task<IEnumerable<AlunoResponseDto>> ListarAsync(int page, int pageSize);
        Task<IEnumerable<AlunoResponseDto>> BuscarPorNomeAsync(string nome);
        Task<bool> AtualizarAsync(Guid id, UpdateAlunoDto dto);
        Task<bool> RemoverAsync(Guid id);
    }
}
