using Microsoft.AspNetCore.Mvc; // Namespace necessário para APIs
using Microsoft.EntityFrameworkCore; // Necessário para usar ToListAsync(), FindAsync() e SaveChangesAsync()
using ApiAgendamentos.Data; // Para o AppDbContext
using ApiAgendamentos.Models; // Para o modelo Agendamento
using System.Threading.Tasks; // Para métodos assíncronos
using System.Collections.Generic; // Para IEnumerable<T>
using System; // Adicionado para trabalhar com Guid

namespace ApiAgendamentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/agendamentos - Retorna todos os agendamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
        {
            var agendamentos = await _context.Agendamentos.ToListAsync();
            if (agendamentos == null || agendamentos.Count == 0)
            {
                return NotFound("Nenhum agendamento encontrado."); // Status 404 se não encontrar nenhum
            }
            return Ok(agendamentos); // Status 200 com a lista de agendamentos
        }

        // GET: api/agendamentos/{id} - Retorna um agendamento específico por ID
        [HttpGet("{id:guid}")] // Alterado para 'guid' para corresponder ao tipo Guid
        public async Task<ActionResult<Agendamento>> GetAgendamentoById(Guid id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound($"Agendamento com ID {id} não encontrado."); // Status 404
            }
            return Ok(agendamento); // Status 200 com o agendamento
        }

        // POST: api/agendamentos - Cria um novo agendamento
        [HttpPost]
        public async Task<ActionResult<Agendamento>> CreateAgendamento([FromBody] Agendamento agendamento)
        {
            if (agendamento == null)
            {
                return BadRequest("O corpo da requisição não contém um agendamento válido."); // Status 400
            }

            await _context.Agendamentos.AddAsync(agendamento); // Adiciona o agendamento
            await _context.SaveChangesAsync(); // Salva no banco de dados

            // Retorna status 201 com o local do recurso criado
            return CreatedAtAction(nameof(GetAgendamentoById), new { id = agendamento.Id }, agendamento);
        }

        // PUT: api/agendamentos/{id} - Atualiza um agendamento existente
        [HttpPut("{id:guid}")] // Alterado para 'guid' para corresponder ao tipo Guid
        public async Task<IActionResult> UpdateAgendamento(Guid id, [FromBody] Agendamento agendamento)
        {
            if (agendamento == null)
            {
                return BadRequest("O corpo da requisição não contém um agendamento válido."); // Status 400
            }

            if (agendamento.Id != id)
            {
                return BadRequest("O ID do agendamento não corresponde ao ID fornecido."); // Status 400
            }

            var agendamentoExistente = await _context.Agendamentos.FindAsync(id);
            if (agendamentoExistente == null)
            {
                return NotFound($"Agendamento com ID {id} não encontrado."); // Status 404
            }

            // Atualiza os campos necessários
            agendamentoExistente.NomeCliente = agendamento.NomeCliente;
            agendamentoExistente.DataHora = agendamento.DataHora;
            agendamentoExistente.Servico = agendamento.Servico;
            agendamentoExistente.Observacoes = agendamento.Observacoes;

            _context.Entry(agendamentoExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); // Status 204 (sem conteúdo)
        }

        // DELETE: api/agendamentos/{id} - Exclui um agendamento existente
        [HttpDelete("{id:guid}")] // Alterado para 'guid' para corresponder ao tipo Guid
        public async Task<IActionResult> DeleteAgendamento(Guid id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound($"Agendamento com ID {id} não encontrado."); // Status 404
            }

            _context.Agendamentos.Remove(agendamento); // Remove o agendamento
            await _context.SaveChangesAsync();

            return NoContent(); // Status 204 (sem conteúdo)
        }
    }
}
