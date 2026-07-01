using SistemaGestaoAlunos.Domain.Entities;

namespace SistemaGestaoAlunos.Domain.Interfaces.Auth;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task AdicionarAsync(Usuario usuario);
}

