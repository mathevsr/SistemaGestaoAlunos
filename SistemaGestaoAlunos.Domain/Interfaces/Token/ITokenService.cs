using SistemaGestaoAlunos.Domain.Entities;

namespace SistemaGestaoAlunos.Application.Services.Interfaces;

public interface ITokenService
{
    string GerarToken(Usuario usuario);
}
