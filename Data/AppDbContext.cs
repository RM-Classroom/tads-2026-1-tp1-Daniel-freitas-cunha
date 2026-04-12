using Microsoft.EntityFrameworkCore;
using Trabalho_Daniel_Locadora_veiculo.Models;

namespace Trabalho_Daniel_Locadora_veiculo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<LocacaoCarro> Locacoes { get; set; }
    }
}