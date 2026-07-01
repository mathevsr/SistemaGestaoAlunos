using SistemaGestaoAlunos.Application.DTOs.Aluno;
using SistemaGestaoAlunos.Domain.Entities;
using SistemaGestaoAlunos.Domain.Interfaces;

namespace SistemaGestaoAlunos.Application.Services.Alunos;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoService(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    // ---------------- CREATE ----------------
    public async Task<AlunoResponseDto> CriarAsync(CreateAlunoDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
            throw new ArgumentException("Nome é obrigatório.");
        if (dto.Nome.Length < 3)
            throw new ArgumentException("Nome deve ter no mínimo 3 caracteres.");
        if (dto.Altura <= 0)
            throw new ArgumentException("Altura deve ser maior que zero.");
        if (dto.Peso <= 0)
            throw new ArgumentException("Peso deve ser maior que zero.");

        var aluno = new Aluno(dto.Nome, dto.DataNascimento, dto.Altura, dto.Peso);
        await _alunoRepository.AdicionarAsync(aluno);
        return MapToDto(aluno);
    }

    // ---------------- READ ----------------
    public async Task<IEnumerable<AlunoResponseDto>> ListarAsync(int page, int pageSize)
    {
        var alunos = await _alunoRepository.ListarAsync(page, pageSize);
        return alunos.Select(MapToDto);
    }

    // ---------------- UPDATE ----------------
    public async Task<bool> AtualizarAsync(Guid id, UpdateAlunoDto dto)
    {
        var aluno = await _alunoRepository.ObterPorIdAsync(id);
        if (aluno == null) return false;

        if (string.IsNullOrWhiteSpace(dto.Nome))
            throw new ArgumentException("Nome é obrigatório.");
        if (dto.Nome.Length < 3)
            throw new ArgumentException("Nome deve ter no mínimo 3 caracteres.");
        if (dto.Altura <= 0)
            throw new ArgumentException("Altura deve ser maior que zero.");
        if (dto.Peso <= 0)
            throw new ArgumentException("Peso deve ser maior que zero.");

        aluno.AtualizarDados(dto.Nome, dto.DataNascimento, dto.Altura, dto.Peso);
        await _alunoRepository.SalvarAsync();
        return true;
    }

    // ---------------- DELETE ----------------
    public async Task<bool> RemoverAsync(Guid id)
    {
        var aluno = await _alunoRepository.ObterPorIdAsync(id);
        if (aluno == null) return false;

        await _alunoRepository.RemoverAsync(aluno);
        return true;
    }

    // ---------------- SEARCH ----------------
    public async Task<IEnumerable<AlunoResponseDto>> BuscarPorNomeAsync(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return Enumerable.Empty<AlunoResponseDto>();

        var alunos = await _alunoRepository.BuscarPorNomeAsync(nome);
        return alunos.Select(MapToDto);
    }

    // ---------------- HELPER ----------------
    private static AlunoResponseDto MapToDto(Aluno aluno) => new()
    {
        Id = aluno.Id,
        Nome = aluno.Nome,
        DataNascimento = aluno.DataNascimento,
        Altura = aluno.Altura,
        Peso = aluno.Peso
    };
}
