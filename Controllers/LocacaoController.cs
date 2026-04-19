using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho_Daniel_Locadora_veiculo.Data;
using Trabalho_Daniel_Locadora_veiculo.Models;

namespace Trabalho_Daniel_Locadora_veiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocacaoCarro>>> Get()
        {
            return await _context.Locacoes
                .Include(l => l.Cliente)
                .Include(l => l.Veiculo)
                .ToListAsync();
        }

        /// <summary>
        /// Registra uma nova locação de veículo.
        /// </summary>

        [HttpPost]
        public async Task<ActionResult> Post(LocacaoCarro locacao)
        {
            try
            {
                _context.Locacoes.Add(locacao);
                await _context.SaveChangesAsync();
                return Ok(locacao);
            }
            catch (Exception ex) 
            {
                return BadRequest($"Não foi possivel cadastrar Locacao{ex.Message}");
            }
        }

        [HttpGet("cliente/{id}")]
        public async Task<ActionResult> GetPorCliente(int id)
        {
            var result = await _context.Locacoes
                .Include(loc => loc.Cliente)
                .Include(loc => loc.Veiculo)
                .Where(loc => loc.ClienteId == id)
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("valor/{valor}")]
        public async Task<ActionResult> GetPorValor(decimal valor)
        {
            var result = await _context.Locacoes
                .Include(l => l.Cliente)
                .Where(l => l.ValorTotal > valor)
                .ToListAsync();

            return Ok(result);
        }

        /// <summary>
        /// Relatório detalhado de todas as locações (Múltiplos JOINS).
        /// </summary>

        [HttpGet("completo")]
        public async Task<ActionResult> RelatorioCompleto()
        {
            var result = await _context.Locacoes
                .Include(l => l.Cliente)
                .Include(l => l.Veiculo)
                    .ThenInclude(v => v.Fabricante)
                .Include(l => l.Veiculo)
                    .ThenInclude(v => v.Categoria)
                .ToListAsync();

            return Ok(result);
        }

    }
}
