using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho_Daniel_Locadora_veiculo.Data;
using Trabalho_Daniel_Locadora_veiculo.Models;

namespace Trabalho_Daniel_Locadora_veiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            return await _context.Categorias.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel Cadastrar Categoria!{ex.Message}");
            }
        }
    }
}
