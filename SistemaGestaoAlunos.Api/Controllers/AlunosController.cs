using Microsoft.AspNetCore.Mvc;
using SistemaGestaoAlunos.Application.DTOs.Aluno;
using SistemaGestaoAlunos.Application.Services.Alunos;

namespace SistemaGestaoAlunos.Api.Controllers
{
    // Indica que esta classe é um Controller de API
    [ApiController]

    // Define a rota base: api/alunos
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        // Interface do serviço de alunos (injeção de dependência)
        private readonly IAlunoService _alunoService;

        // Construtor recebe o serviço automaticamente pelo container DI
        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        // Endpoint HTTP POST → criar um aluno
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateAlunoDto dto)
        {
            try
            {
                var aluno = await _alunoService.CriarAsync(dto);
                return Created(string.Empty, aluno);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Endpoint HTTP GET → listar alunos com paginação
        [HttpGet]
        public async Task<IActionResult> Listar(
            [FromQuery] int page = 1,       // Página atual (default = 1)
            [FromQuery] int pageSize = 10)  // Quantidade por página
        {
            // Busca os alunos aplicando paginação
            var alunos = await _alunoService.ListarAsync(page, pageSize);

            // Retorna HTTP 200 com a lista
            return Ok(alunos);
        }
        // Endpoint HTTP PUT → atualizar um aluno
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] UpdateAlunoDto dto)
        {
            try
            {
                var atualizado = await _alunoService.AtualizarAsync(id, dto);

                if (!atualizado)
                    return NotFound();

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint HTTP DELETE → remover um aluno
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            // Chama o service para remover
            var removido = await _alunoService.RemoverAsync(id);

            // Se não encontrou o aluno, retorna 404
            if (!removido)
                return NotFound("Aluno não encontrado");

            // Se removeu com sucesso, retorna 204
            return NoContent();
        }

        // GET api/alunos/buscar?nome=Matheus
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNome([FromQuery] string nome)
        {
            // Chama o serviço
            var alunos = await _alunoService.BuscarPorNomeAsync(nome);

            // Retorna 200 OK com a lista (mesmo vazia)
            return Ok(alunos);
        }


    }
}
