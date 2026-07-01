using Microsoft.EntityFrameworkCore;
using SistemaGestaoAlunos.Domain.Entities;
using SistemaGestaoAlunos.Domain.Interfaces;
using SistemaGestaoAlunos.Infrastructure.Data;

namespace SistemaGestaoAlunos.Infrastructure.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly AppDbContext _context;

    public AlunoRepository(AppDbContext context) => _context = context;

    public async Task<Aluno> AdicionarAsync(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
        return aluno;
    }

    public async Task<Aluno?> ObterPorIdAsync(Guid id) =>
        await _context.Alunos.FindAsync(id);

    public async Task<IEnumerable<Aluno>> ListarAsync(int page, int pageSize) =>
        await _context.Alunos
            .OrderBy(a => a.Nome)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

    public async Task<IEnumerable<Aluno>> BuscarPorNomeAsync(string nome) =>
        await _context.Alunos
            .Where(a => a.Nome.Contains(nome))
            .OrderBy(a => a.Nome)
            .ToListAsync();

    public async Task SalvarAsync() =>
        await _context.SaveChangesAsync();

    public async Task RemoverAsync(Aluno aluno)
    {
        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();
    }
}