using System;

namespace SistemaGestaoAlunos.Application.DTOs.Auth;

public record RegisterDto(string Nome, string Email, string Senha);