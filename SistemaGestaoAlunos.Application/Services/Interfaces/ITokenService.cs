using SistemaGestaoAlunos.Domain.Entities;

namespace SistemaGestaoAlunos.Application.Interfaces;

public interface ITokenService
{
    string GerarToken(Usuario usuario);
}
