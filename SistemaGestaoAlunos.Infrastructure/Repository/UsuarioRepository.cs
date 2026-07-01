using Microsoft.EntityFrameworkCore;
using SistemaGestaoAlunos.Domain.Interfaces.Auth;
using SistemaGestaoAlunos.Domain.Entities;
using SistemaGestaoAlunos.Infrastructure.Data;

namespace SistemaGestaoAlunos.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context) => _context = context;

    public async Task<Usuario?> ObterPorEmailAsync(string email) =>
        await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AdicionarAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }
}
