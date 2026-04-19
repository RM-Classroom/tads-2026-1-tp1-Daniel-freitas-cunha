using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho_Daniel_Locadora_veiculo.Data;
using Trabalho_Daniel_Locadora_veiculo.Models;

namespace Trabalho_Daniel_Locadora_veiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FabricanteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fabricante>>> Get()
        {
            return await _context.Fabricantes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Fabricante fabricante)
        {
            try
            {
                _context.Fabricantes.Add(fabricante);
                await _context.SaveChangesAsync();
                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar Fabricante: {ex.Message}");
            }
        }
    }
}
