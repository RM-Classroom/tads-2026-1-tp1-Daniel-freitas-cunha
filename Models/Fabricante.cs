namespace Trabalho_Daniel_Locadora_veiculo.Models
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Pais { get; set; }

        public List<Veiculo>? Veiculos { get; set; }
    }
}
