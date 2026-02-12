using Microsoft.EntityFrameworkCore;
using SistemaGestaoAlunos.Application.DTOs.Aluno;
using SistemaGestaoAlunos.Domain.Entities;
using SistemaGestaoAlunos.Infrastructure.Data;

namespace SistemaGestaoAlunos.Application.Services.Alunos
{
    // Serviço responsável pelas regras de negócio relacionadas ao Aluno
    public class AlunoService : IAlunoService
    {
        // DbContext do EF Core (acesso ao banco de dados)
        private readonly AppDbContext _context;

        // Construtor com injeção de dependência
        // O ASP.NET Core injeta o AppDbContext automaticamente
        public AlunoService(AppDbContext context)
        {
            _context = context;
        }

        // ---------------- CREATE ----------------
        public async Task<AlunoResponseDto> CriarAsync(CreateAlunoDto dto)
        {
            // Validação 1: Nome obrigatório
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new ArgumentException("Nome é obrigatório.");

            // Validação 2: Nome mínimo
            if (dto.Nome.Length < 3)
                throw new ArgumentException("Nome deve ter no mínimo 3 caracteres.");

            // Validação 3: Altura válida
            if (dto.Altura <= 0)
                throw new ArgumentException("Altura deve ser maior que zero.");

            // Validação 4: Peso válido
            if (dto.Peso <= 0)
                throw new ArgumentException("Peso deve ser maior que zero.");

            // Cria a entidade
            var aluno = new Aluno(
                dto.Nome,
                dto.DataNascimento,
                dto.Altura,
                dto.Peso
            );

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return new AlunoResponseDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Altura = aluno.Altura,
                Peso = aluno.Peso
            };
        }


        // ---------------- READ ----------------
        public async Task<IEnumerable<AlunoResponseDto>> ListarAsync(int page, int pageSize)
        {
            // Busca os alunos no banco com paginação
            return await _context.Alunos
                .OrderBy(a => a.Nome)                 // Ordena pelo nome
                .Skip((page - 1) * pageSize)          // Pula registros
                .Take(pageSize)                       // Limita quantidade
                .Select(a => new AlunoResponseDto     // Mapeia para DTO
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    DataNascimento = a.DataNascimento,
                    Altura = a.Altura,
                    Peso = a.Peso
                })
                .ToListAsync();                       // Executa no banco
        }

        // ---------------- UPDATE ----------------
        public async Task<bool> AtualizarAsync(Guid id, UpdateAlunoDto dto)
        {
            // Busca aluno
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                return false;

            // Validações
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new ArgumentException("Nome é obrigatório.");

            if (dto.Nome.Length < 3)
                throw new ArgumentException("Nome deve ter no mínimo 3 caracteres.");

            if (dto.Altura <= 0)
                throw new ArgumentException("Altura deve ser maior que zero.");

            if (dto.Peso <= 0)
                throw new ArgumentException("Peso deve ser maior que zero.");

            // Atualiza dados
            aluno.AtualizarDados(
                dto.Nome,
                dto.DataNascimento,
                dto.Altura,
                dto.Peso
            );

            await _context.SaveChangesAsync();
            return true;
        }


        // ---------------- DELETE ----------------
        public async Task<bool> RemoverAsync(Guid id)
        {
            // Busca o aluno pelo ID
            var aluno = await _context.Alunos.FindAsync(id);

            // Se não existir, retorna false
            if (aluno == null)
                return false;

            // Remove o aluno do contexto
            _context.Alunos.Remove(aluno);

            // Persiste a remoção no banco
            await _context.SaveChangesAsync();

            return true;
        }
        // ---------------- SEARCH ----------------
        public async Task<IEnumerable<AlunoResponseDto>> BuscarPorNomeAsync(string nome)
        {
            // Se o nome vier vazio ou nulo, retorna lista vazia
            if (string.IsNullOrWhiteSpace(nome))
                return Enumerable.Empty<AlunoResponseDto>();

            // Busca no banco usando LIKE (%nome%)
            return await _context.Alunos
                .Where(a => a.Nome.Contains(nome))
                .OrderBy(a => a.Nome)
                .Select(a => new AlunoResponseDto
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    DataNascimento = a.DataNascimento,
                    Altura = a.Altura,
                    Peso = a.Peso
                })
                .ToListAsync();
        }

    }
}

