using System;


namespace SistemaGestaoAlunos.Application.DTOs.Auth;

public record LoginDto(string Email, string Senha);