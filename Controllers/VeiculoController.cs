using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho_Daniel_Locadora_veiculo.Data;
using Trabalho_Daniel_Locadora_veiculo.Models;

namespace Trabalho_Daniel_Locadora_veiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> Get()
        {
            return await _context.Veiculos
                .Include(v => v.Fabricante)
                .Include(v => v.Categoria)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> Get(int id)
        {
            var veiculo = await _context.Veiculos
                .Include(v => v.Fabricante)
                .Include(v => v.Categoria)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (veiculo == null) return NotFound();

            return veiculo;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return Ok(veiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id) return BadRequest();

            _context.Entry(veiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var v = await _context.Veiculos.FindAsync(id);
            if (v == null) return NotFound();

            _context.Veiculos.Remove(v);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Filtros com Joins

        [HttpGet("fabricante/{id}")]
        public async Task<ActionResult> GetPorFabricante(int id)
        {
            var result = await _context.Veiculos
                .Include(v => v.Fabricante)
                .Where(v => v.FabricanteId == id)
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("categoria/{id}")]
        public async Task<ActionResult> GetPorCategoria(int id)
        {
            var result = await _context.Veiculos
                .Include(v => v.Categoria)
                .Where(v => v.CategoriaId == id)
                .ToListAsync();

            return Ok(result);
        }
    }

}
