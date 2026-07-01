using SistemaGestaoAlunos.Domain.Entities;

namespace SistemaGestaoAlunos.Domain.Interfaces;

public interface IAlunoRepository
{
    Task<Aluno> AdicionarAsync(Aluno aluno);
    Task<Aluno?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Aluno>> ListarAsync(int page, int pageSize);
    Task<IEnumerable<Aluno>> BuscarPorNomeAsync(string nome);
    Task SalvarAsync();
    Task RemoverAsync(Aluno aluno);
}