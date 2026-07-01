using SistemaGestaoAlunos.Application.DTOs.Auth;

namespace SistemaGestaoAlunos.Application.Interfaces;

public interface IAuthService
{
    Task<TokenDto?> LoginAsync(LoginDto dto);
    Task<bool> RegisterAsync(RegisterDto dto);
}
