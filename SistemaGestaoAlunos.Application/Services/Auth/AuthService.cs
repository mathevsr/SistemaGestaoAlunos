using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaGestaoAlunos.Application.DTOs.Auth;
using SistemaGestaoAlunos.Application.Interfaces;
using SistemaGestaoAlunos.Application.Services.Auth;
using SistemaGestaoAlunos.Domain.Entities;
using SistemaGestaoAlunos.Domain.Interfaces.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaGestaoAlunos.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }
    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        // Verifica se já existe um usuário com esse email
        var existe = await _usuarioRepository.ObterPorEmailAsync(dto.Email);
        if (existe != null) return false;

        // Cria o hash da senha 
        var senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

        // Cria o usuário usando o construtor 
        var usuario = new Usuario(dto.Nome, dto.Email, senhaHash, "User");

        await _usuarioRepository.AdicionarAsync(usuario);
        return true;
    }

    public async Task<TokenDto?> LoginAsync(LoginDto dto)
    {
        // Busca o usuário pelo email
        var usuario = await _usuarioRepository.ObterPorEmailAsync(dto.Email);
        if (usuario == null) return null;

        // Verifica se a senha está correta
        var senhaValida = BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);
        if (!senhaValida) return null;

        // Gera e retorna o token JWT
        return new TokenDto(GerarToken(usuario));
    }

    private string GerarToken(Usuario usuario)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Role)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
