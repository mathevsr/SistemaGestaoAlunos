using Microsoft.AspNetCore.Mvc;
using SistemaGestaoAlunos.Application.DTOs.Auth;
using SistemaGestaoAlunos.Application.Interfaces;
using SistemaGestaoAlunos.Application.Services.Auth;

namespace SistemaGestaoAlunos.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var sucesso = await _authService.RegisterAsync(dto);

        if (!sucesso)
            return Conflict("Email já cadastrado.");

        return Created(string.Empty, "Usuário registrado com sucesso.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _authService.LoginAsync(dto);

        if (token == null)
            return Unauthorized("Email ou senha inválidos.");

        return Ok(token);
    }
}